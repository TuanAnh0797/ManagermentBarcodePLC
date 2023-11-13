﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCProtocolLibrary
{
    public class ConnectPLC
    {
        
        byte[] buffDeleteword = new byte[100];
        int lenghtdatawrite;
        StringBuilder strb = new StringBuilder();
        byte[] buffwritebit = new byte[100];
        byte[] buffreadbit = new byte[100];
        byte[] buffreadASCII = new byte[1000];
        byte[] buffreadDEC = new byte[100];
        private IPAddress ipaddressserver;
        private int portserver;
        TcpClient client;
        private NetworkStream stream;
        public IPAddress Ipaddressserver { get => ipaddressserver; }
        public int Portserver { get => portserver; }
        public bool SetIpAddress(string _IPAddressServer)
        {
            IPAddress ipaddr = null;
            if (!IPAddress.TryParse(_IPAddressServer, out ipaddr))
            {
                return false;
            }
            ipaddressserver = ipaddr;
            return true;
        }
        public ConnectPLC()
        {
            client = new TcpClient();
        }
        public ConnectPLC(string ipaddresss, string portnumberr)
        {
            client = new TcpClient();
            IPAddress.TryParse(ipaddresss, out ipaddressserver);
            int portNumber = 0;
            if (!int.TryParse(portnumberr.Trim(), out portNumber))
            {
                portserver = -1;
            }
            else if (portNumber <= 0 || portNumber > 65535)
            {
                portserver = -1;
            }
            else
            {
                portserver = portNumber;
            }
        }
        public bool SetPortNumber(string _ServerPort)
        {
            int portNumber = 0;
            if (!int.TryParse(_ServerPort.Trim(), out portNumber))
            {
                return false;
            }
            if (portNumber <= 0 || portNumber > 65535)
            {
                return false;
            }
            portserver = portNumber;
            return true;
        }
        public async Task OpenConnection(string erroropenconnect)
        {
            client = new TcpClient();
            client.ReceiveTimeout = 2000;
            try
            {
                client.ConnectAsync(ipaddressserver, portserver).Wait(3000);
            }
            catch (Exception excp)
            {
                erroropenconnect = excp.Message;
            }
        }
        public async Task<string> readASCII(string Devicestr, int HeaderDeviceint, int NumberofDeviceint)
        {
            byte[] finalcmd = new byte[21];
            byte[] pathcmd = { 0x50, 0x00, 0x00, 0xff, 0xff, 0x03, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x01, 0x04, 0x00, 0x00 };
            byte[] HeaderDevice = BitConverter.GetBytes(HeaderDeviceint);
            byte[] Device = Converttextdevicetohexdevice(Devicestr);
            byte[] NumberofDevice = BitConverter.GetBytes(NumberofDeviceint);
            Buffer.BlockCopy(pathcmd, 0, finalcmd, 0, pathcmd.Length);
            Buffer.BlockCopy(HeaderDevice, 0, finalcmd, pathcmd.Length, 3);
            Buffer.BlockCopy(Device, 0, finalcmd, pathcmd.Length + 3, 1);
            Buffer.BlockCopy(NumberofDevice, 0, finalcmd, pathcmd.Length + 4, 2);
            if (client != null)
            {
                if (client.Connected)
                {
                    Array.Clear(buffreadASCII, 0, buffreadASCII.Length);
                    stream = client.GetStream();
                    await stream.WriteAsync(finalcmd, 0, finalcmd.Length);
                    await stream.ReadAsync(buffreadASCII, 0, buffreadASCII.Length);
                    if (buffreadASCII[9] == 0 && buffreadASCII[10] == 0)
                    {
                        return Encoding.ASCII.GetString(buffreadASCII, 10, 80).Trim('\0');
                    }
                }
            }
            return null;
        }
        public async Task<int> readDEC(string Devicestr, int HeaderDeviceint)
        {
            byte[] finalcmd = new byte[21];
            byte[] pathcmd = { 0x50, 0x00, 0x00, 0xff, 0xff, 0x03, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x01, 0x04, 0x00, 0x00 };
            byte[] HeaderDevice = BitConverter.GetBytes(HeaderDeviceint);
            byte[] Device = Converttextdevicetohexdevice(Devicestr);
            byte[] NumberofDevice = BitConverter.GetBytes(1);
            Buffer.BlockCopy(pathcmd, 0, finalcmd, 0, pathcmd.Length);

            Buffer.BlockCopy(HeaderDevice, 0, finalcmd, pathcmd.Length, 3);
            Buffer.BlockCopy(Device, 0, finalcmd, pathcmd.Length + 3, 1);
            Buffer.BlockCopy(NumberofDevice, 0, finalcmd, pathcmd.Length + 4, 2);
            if (client != null)
            {
                if (client.Connected)
                {
                    Array.Clear(buffreadDEC, 0, buffreadDEC.Length);
                    stream = client.GetStream();
                    await stream.WriteAsync(finalcmd, 0, finalcmd.Length);
                    await stream.ReadAsync(buffreadDEC, 0, buffreadDEC.Length);
                    if (buffreadDEC[9] == 0 && buffreadDEC[10] == 0)
                    {
                        return BitConverter.ToInt32(buffreadDEC, 11);

                    }
                }
            }
            return 0;
        }
        public async Task<int> readbit(string Devicestr, int HeaderDeviceint, int NumberofDeviceint)
        {
            byte[] finalcmd = new byte[21];
            byte[] pathcmd = { 0x50, 0x00, 0x00, 0xff, 0xff, 0x03, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x01, 0x04, 0x01, 0x00 };
            byte[] HeaderDevice = BitConverter.GetBytes(HeaderDeviceint);
            byte[] Device = Converttextdevicetohexdevice(Devicestr);
            byte[] NumberofDevice = BitConverter.GetBytes(NumberofDeviceint);
            Buffer.BlockCopy(pathcmd, 0, finalcmd, 0, pathcmd.Length);
            Buffer.BlockCopy(HeaderDevice, 0, finalcmd, pathcmd.Length, 3);
            Buffer.BlockCopy(Device, 0, finalcmd, pathcmd.Length + 3, 1);
            Buffer.BlockCopy(NumberofDevice, 0, finalcmd, pathcmd.Length + 4, 2);
            if (client != null)
            {
                if (client.Connected)
                {
                    Array.Clear(buffreadbit, 0, buffreadbit.Length);
                    stream = client.GetStream();
                    await stream.WriteAsync(finalcmd, 0, finalcmd.Length);
                    await stream.ReadAsync(buffreadbit, 0, buffreadbit.Length);
                    if (buffreadbit[9] == 0 && buffreadbit[10] == 0)
                    {
                        return BitConverter.ToInt32(buffreadbit, 11);
                    }
                }
            }
            return 0;
        }
        public async Task writebit(string Devicestr, int HeaderDeviceint, string OnorOff)
        {
            byte[] On = { 0x10 };
            byte[] Off = { 0x00 };
            byte[] Onoff = null;
            byte[] finalcmd = new byte[22];
            byte[] pathcmd = { 0x50, 0x00, 0x00, 0xff, 0xff, 0x03, 0x00, 0x0D, 0x00, 0x00, 0x00, 0x01, 0x14, 0x01, 0x00 };
            byte[] HeaderDevice = BitConverter.GetBytes(HeaderDeviceint);
            byte[] Device = Converttextdevicetohexdevice(Devicestr);
            byte[] NumberofDevice = { 0x01, 0x00 };
            if (OnorOff == "On")
            {
                Onoff = On;
            }
            else
            {
                Onoff = Off;
            }
            Buffer.BlockCopy(pathcmd, 0, finalcmd, 0, pathcmd.Length);
            Buffer.BlockCopy(HeaderDevice, 0, finalcmd, pathcmd.Length, 3);
            Buffer.BlockCopy(Device, 0, finalcmd, pathcmd.Length + 3, 1);
            Buffer.BlockCopy(NumberofDevice, 0, finalcmd, pathcmd.Length + 4, 2);
            Buffer.BlockCopy(Onoff, 0, finalcmd, pathcmd.Length + 6, 1);
            if (client != null)
            {
                if (client.Connected)
                {
                    stream = client.GetStream();
                    await stream.WriteAsync(finalcmd, 0, finalcmd.Length);
                    await stream.ReadAsync(buffwritebit, 0, buffwritebit.Length);
                    Array.Clear(buffwritebit, 0, buffwritebit.Length);
                }
            }
        }
        public async Task writeword(string Devicestr, int HeaderDeviceint, int NumberofDeviceint, string datawrite)
        {
            byte[] pathcmd1 = { 0x50, 0x00, 0x00, 0xff, 0xff, 0x03, 0x00 };
            byte[] pathcmd3 = { 0x00, 0x00, 0x01, 0x14, 0x00, 0x00 };
            byte[] HeaderDevice = BitConverter.GetBytes(HeaderDeviceint);
            byte[] Device = Converttextdevicetohexdevice(Devicestr);
            byte[] NumberofDevice = BitConverter.GetBytes(NumberofDeviceint);
            byte[] datawritetoplc;

            if (datawrite.Length / 2 != NumberofDeviceint)
            {
                strb.Clear();
                strb.Append(datawrite);
                lenghtdatawrite = datawrite.Length;
                for (int i = 0; i < NumberofDeviceint * 2 - lenghtdatawrite; i++)
                {
                    strb.Append("\u0000");
                }
                datawrite = strb.ToString();
                datawritetoplc = Encoding.ASCII.GetBytes(datawrite);
            }
            else
            {
                datawritetoplc = Encoding.ASCII.GetBytes(datawrite);
            }
            byte[] path2 = BitConverter.GetBytes(pathcmd3.Length + 6 + datawritetoplc.Length);
            byte[] finalcmd = new byte[21 + datawritetoplc.Length];
            Buffer.BlockCopy(pathcmd1, 0, finalcmd, 0, pathcmd1.Length);
            Buffer.BlockCopy(path2, 0, finalcmd, 7, 2);
            Buffer.BlockCopy(pathcmd3, 0, finalcmd, 9, pathcmd3.Length);
            Buffer.BlockCopy(HeaderDevice, 0, finalcmd, 9 + pathcmd3.Length, 3);
            Buffer.BlockCopy(Device, 0, finalcmd, 12 + pathcmd3.Length, 1);
            Buffer.BlockCopy(NumberofDevice, 0, finalcmd, 13 + pathcmd3.Length, 2);
            Buffer.BlockCopy(datawritetoplc, 0, finalcmd, 15 + pathcmd3.Length, datawritetoplc.Length);
            if (client != null)
            {
                if (client.Connected)
                {
                    stream = client.GetStream();
                    await stream.WriteAsync(finalcmd, 0, finalcmd.Length);
                    byte[] buff = new byte[100];
                    await stream.ReadAsync(buff, 0, buff.Length);
                    Array.Clear(buff, 0, buff.Length);
                }
            }

        }
        public async Task Deleteword(string Devicestr, int HeaderDeviceint, int NumberofDeviceint)
        {
            byte[] pathcmd1 = { 0x50, 0x00, 0x00, 0xff, 0xff, 0x03, 0x00 };
            byte[] pathcmd3 = { 0x00, 0x00, 0x01, 0x14, 0x00, 0x00 };
            byte[] HeaderDevice = BitConverter.GetBytes(HeaderDeviceint);
            byte[] Device = Converttextdevicetohexdevice(Devicestr);
            byte[] NumberofDevice = BitConverter.GetBytes(NumberofDeviceint);
            byte[] Valuenull = { 0x00, 0x00 };
            byte[] datawritetoplc = new byte[2 * NumberofDeviceint];
            for (int i = 0; i < NumberofDeviceint; i++)
            {
                Valuenull.CopyTo(datawritetoplc, 2 * i);
            }
            byte[] path2 = BitConverter.GetBytes(pathcmd3.Length + 6 + datawritetoplc.Length);
            byte[] finalcmd = new byte[21 + datawritetoplc.Length];
            Buffer.BlockCopy(pathcmd1, 0, finalcmd, 0, pathcmd1.Length);
            Buffer.BlockCopy(path2, 0, finalcmd, 7, 2);
            Buffer.BlockCopy(pathcmd3, 0, finalcmd, 9, pathcmd3.Length);
            Buffer.BlockCopy(HeaderDevice, 0, finalcmd, 9 + pathcmd3.Length, 3);
            Buffer.BlockCopy(Device, 0, finalcmd, 12 + pathcmd3.Length, 1);
            Buffer.BlockCopy(NumberofDevice, 0, finalcmd, 13 + pathcmd3.Length, 2);
            Buffer.BlockCopy(datawritetoplc, 0, finalcmd, 15 + pathcmd3.Length, datawritetoplc.Length);
            if (client != null)
            {
                if (client.Connected)
                {
                    stream = client.GetStream();
                    await stream.WriteAsync(finalcmd, 0, finalcmd.Length);
                    await stream.ReadAsync(buffDeleteword, 0, buffDeleteword.Length);
                    Array.Clear(buffDeleteword, 0, buffDeleteword.Length);
                }
            }
        }
        public bool statusconect()
        {
            if (client.Connected)
            {
                return true;
            }
            else
                return false;
        }
        public void disconnectandclose()
        {
            if (client != null)
            {
                if (client.Connected)
                {
                    client.Close();
                    client.Dispose();
                }
            }
            GC.Collect();
        }
        public static byte[] Converttextdevicetohexdevice(string namedevice)
        {
            byte[] bytereturn = null;
            byte[] X = { 0x9C };
            byte[] Y = { 0x9D };
            byte[] M = { 0x90 };
            byte[] L = { 0x92 };
            byte[] B = { 0xA0 };
            byte[] D = { 0xA8 };
            byte[] W = { 0xB4 };
            byte[] ZR = { 0xB0 };

            Dictionary<string, byte[]> data = new Dictionary<string, byte[]>();
            data.Add("X", X);
            data.Add("Y", Y);
            data.Add("M", M);
            data.Add("L", L);
            data.Add("B", B);
            data.Add("D", D);
            data.Add("W", W);
            data.Add("ZR", ZR);

            foreach (var item in data)
            {
                if (namedevice == item.Key)
                {
                    bytereturn = item.Value;
                }
            }
            return bytereturn;
        }
    }
}

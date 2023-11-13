using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MCProtocolLibrary;

namespace BarcodeManagerment
{
    public partial class Main : Form
    {
        List<datamaster> listdt = new List<datamaster>();
        string MCaddress;
        int totalcode;
        string mcip;
        int mcport;
        public Main()
        {
            InitializeComponent();
            try
            {
                loaddata();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
        public void loaddata()
        {
            DataTable dt = DBConnect.StoreFillDS("getdatamastercombobox", CommandType.StoredProcedure);
            List<string> datacmb = new List<string>();
            datacmb = dt.AsEnumerable().Select(row => row.Field<string>("Namemachine")).ToList();
            cmb_function.DataSource = datacmb;
        }

        private void btn_loaddatabase_Click(object sender, EventArgs e)
        {
            loaddatafridview();
        }

        private void btn_savedatabase_Click(object sender, EventArgs e)
        {
            updaloaddatabase();
        }
        public void updaloaddatabase()
        {
            if (cmb_function.Items.Contains(cmb_function.Text))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(DBConnect.connection_string))
                    {
                        connection.Open();
                        DataTable dt = new DataTable();
                        dt = (DataTable)dtg_data.DataSource;
                        //if (dt.Rows.Count > 0)
                        //{
                        //    for (int i = 0; i < dt.Rows.Count; i++)
                        //    {
                        //        if (dt.Rows[i][0].ToString() == "")
                        //        {
                        //            dt.Rows[i].Delete();
                        //        }
                        //    }
                        //}
                        using (SqlCommand deleteCommand = new SqlCommand($"DELETE FROM {cmb_function.Text}", connection))
                        {
                            deleteCommand.ExecuteNonQuery();
                        }

                        // Cập nhật dữ liệu mới từ DataTable vào bảng SQL
                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                        {
                            bulkCopy.DestinationTableName = $"{cmb_function.Text}";
                            bulkCopy.WriteToServer(dt);
                        }

                        connection.Close();
                    }
                    MessageBox.Show("Cập nhật thành công");
                   loaddatafridview();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show($"Không tồn tại: {cmb_function.Text}");
            }
               
        }

        private void btn_exportcsv_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "CSV Files|*.csv";
            saveFileDialog1.Title = "Save CSV File";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;

                // Đoạn mã để lưu dữ liệu từ DataGridView ra tệp CSV ở vị trí đã chọn.
                DataTable dt = new DataTable();

                foreach (DataGridViewColumn column in dtg_data.Columns)
                {
                    dt.Columns.Add(column.HeaderText, typeof(string));
                }

                foreach (DataGridViewRow row in dtg_data.Rows)
                {
                    DataRow dataRow = dt.NewRow();

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dataRow[cell.ColumnIndex] = cell.Value;
                    }

                    dt.Rows.Add(dataRow);
                }

                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        sw.Write(column.ColumnName + ",");
                    }

                    sw.WriteLine();

                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (var item in row.ItemArray)
                        {
                            sw.Write(item.ToString() + ",");
                        }

                        sw.WriteLine();
                    }
                }
            }


        }

        

        private void dtg_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //using (TcpClient tcpClient = new TcpClient())
            //{
            //    tcpClient.Connect(IPAddress.Parse(mcip), mcport);
               
            //            for (int j = 0; j < listdt.Count; j++)
            //            {
            //                if (listdt[j].DataType == "DEC")
            //                {
            //                    writeint(tcpClient, listdt[j].DeviceType, listdt[j].StartDevice + listdt[j].LenghtDevice * e.RowIndex, dtg_data.Rows[e.RowIndex].Cells[j + 1].Value == null ? 0 : Convert.ToInt32(dtg_data.Rows[e.RowIndex].Cells[j + 1].Value.ToString()));

            //                }
            //                else if (listdt[j].DataType == "Float")
            //                {
            //                    writefloat(tcpClient, listdt[j].DeviceType, listdt[j].StartDevice + listdt[j].LenghtDevice * e.RowIndex, dtg_data.Rows[e.RowIndex].Cells[j + 1].Value == null ? 0 : float.Parse(dtg_data.Rows[e.RowIndex].Cells[j + 1].Value.ToString()));

            //                }

            //                else
            //                {
            //                    writeword(tcpClient, listdt[j].DeviceType, listdt[j].StartDevice + listdt[j].LenghtDevice * e.RowIndex, listdt[j].LenghtDevice, dtg_data.Rows[e.RowIndex].Cells[j + 1].Value.ToString());

            //                }


            //            }
            //    tcpClient.Close();
            //}
        }
        public void loaddatafridview()
        {
            if (cmb_function.Items.Contains(cmb_function.Text))
            {
                try
                {
                    dtg_data.DataSource = null;
                    using (SqlConnection conn = new SqlConnection(DBConnect.connection_string))
                    {
                        conn.Open();
                        string query = $"Select * from {cmb_function.Text}";
                        DataTable dt = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                        adapter.Fill(dt);
                        dtg_data.DataSource = dt;
                        conn.Close();
                    }
                    if (!dtg_data.Columns.Contains("STT"))
                    {
                        DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn();
                        sttColumn.HeaderText = "STT";
                        sttColumn.Name = "STT";
                        dtg_data.Columns.Insert(0, sttColumn);
                        dtg_data.Columns[0].Width = 60;
                    }
                    for (int i = 0; i < dtg_data.Rows.Count; i++)
                    {
                        dtg_data.Rows[i].Cells["STT"].Value = (i + 1).ToString();
                    }
                    for (int i = 1; i <= listdt.Count; i++)
                    {
                        string strh = dtg_data.Columns[i].HeaderText;
                        dtg_data.Columns[i].HeaderText = strh + $" ({listdt[i-1].DeviceType}{listdt[i-1].StartDevice} - {listdt[i-1].DeviceType}{listdt[i-1].LenghtDevice * totalcode + listdt[i-1].StartDevice})";
                    }
                    
                    dtg_data.Refresh();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show($"Không tồn tại: {cmb_function.Text}");
            }
        }

        private void dtg_data_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int totalcl = dtg_data.Columns.Count;
            for (int i = 0; i < totalcl; i++)
            {
                dtg_data.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                
            }
            //string a = dtg_data.Rows[dtg_data.Rows.Count - 1].Cells[0].Value.ToString();
            if (dtg_data.Rows.Count > totalcode)
            {
                dtg_data.AllowUserToAddRows = false;
            }
            else if (dtg_data.Rows.Count == totalcode && dtg_data.Rows[dtg_data.Rows.Count-1].Cells[1].Value != null){
                dtg_data.AllowUserToAddRows = false;
            }
            else
            {
                dtg_data.AllowUserToAddRows = true;
            }

        }
        private void cmb_function_SelectedIndexChanged(object sender, EventArgs e)
        {
            listdt.Clear();
            dtg_data.DataSource = null;
            dtg_data.Refresh();
            loaddatamaster();
        }
        public void loaddatamaster()
        {
            if (cmb_function.Items.Contains(cmb_function.Text))
            {
                try
                {
                    DataTable dt = new DataTable();
                    using (SqlConnection conn = new SqlConnection(DBConnect.connection_string))
                    {
                        conn.Open();
                        string query = $"Select * from tablemaster where Namemachine = '{cmb_function.Text}' order by indexpart asc ";
                        SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                        adapter.Fill(dt);
                        conn.Close();
                    }
                    if(dt.Rows.Count > 0)
                    {
                        MCaddress = dt.Rows[0]["MCAddress"].ToString();
                        totalcode = (int)dt.Rows[0]["TotalCode"];

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            listdt.Add(new datamaster(dt.Rows[i]["Namepart"].ToString(), dt.Rows[i]["DeviceType"].ToString(), (int)dt.Rows[i]["StartDevice"], dt.Rows[i]["DataType"].ToString(), (int)dt.Rows[i]["LenghtDevice"], (int)dt.Rows[i]["indexpart"]));
                        }
                        using (SqlConnection conn = new SqlConnection(DBConnect.connection_string))
                        {
                            DataTable dt1 = new DataTable();
                            conn.Open();
                            string query = $"Select * from McAddress where Namemachine = '{MCaddress}' ";
                            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                            adapter.Fill(dt1);
                            conn.Close();
                            txb_ip.Text = dt1.Rows[0]["Ipaddress"].ToString();
                            txb_port.Text = dt1.Rows[0]["PortNumber"].ToString();
                            mcip = dt1.Rows[0]["Ipaddress"].ToString();
                            mcport = (int)dt1.Rows[0]["PortNumber"];
                            txb_totalrow.Text = totalcode.ToString();
                        }
                        dtg_data.Refresh();

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void btn_readalldataplc_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                for (int i = 0; i < listdt.Count; i++)
                {
                    if (listdt[i].DataType == "DEC")
                    {
                        dt.Columns.Add(listdt[i].namepart, typeof(int));
                    }
                    else if (listdt[i].DataType == "Float")
                    {
                        dt.Columns.Add(listdt[i].namepart, typeof(float));

                    }
                    else
                    {
                        dt.Columns.Add(listdt[i].namepart, typeof(string));
                    }
                }

                using (TcpClient tcpClient = new TcpClient())
                {
                    tcpClient.Connect(IPAddress.Parse(mcip), mcport);
                    if (listdt.Count > 0)
                    {
                        for (int i = 0; i < totalcode; i++)
                        {
                            DataRow dtr = dt.NewRow();
                            for (int j = 0; j < listdt.Count; j++)
                            {
                                if (listdt[j].DataType == "DEC")
                                {
                                    int? dataplc = readDEC(tcpClient, listdt[j].DeviceType, listdt[j].StartDevice + listdt[j].LenghtDevice * i);
                                    dtr[j] = dataplc;
                                }
                                else if (listdt[j].DataType == "Float")
                                {
                                    float? dataplc = readFloat(tcpClient, listdt[j].DeviceType, listdt[j].StartDevice + listdt[j].LenghtDevice * i);
                                    dtr[j] = dataplc;
                                }

                                else
                                {
                                    String dataplc = readASCII(tcpClient, listdt[j].DeviceType, listdt[j].StartDevice + listdt[j].LenghtDevice * i, listdt[j].LenghtDevice);
                                    dtr[j] = dataplc;
                                }


                            }
                            dt.Rows.Add(dtr);
                        }
                        dtg_data.DataSource = dt;
                        if (!dtg_data.Columns.Contains("STT"))
                        {
                            DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn();
                            sttColumn.HeaderText = "STT";
                            sttColumn.Name = "STT";
                            dtg_data.Columns.Insert(0, sttColumn);
                            dtg_data.Columns[0].Width = 60;
                        }
                        for (int i = 0; i < dtg_data.Rows.Count; i++)
                        {
                            dtg_data.Rows[i].Cells["STT"].Value = (i + 1).ToString();
                        }
                        if (!dtg_data.Columns[2].HeaderText.Contains("("))
                        {
                            for (int i = 1; i <= listdt.Count; i++)
                            {
                                string strh = dtg_data.Columns[i].HeaderText;
                                dtg_data.Columns[i].HeaderText = strh + $" ({listdt[i - 1].DeviceType}{listdt[i - 1].StartDevice} - {listdt[i - 1].DeviceType}{listdt[i - 1].LenghtDevice * totalcode + listdt[i - 1].StartDevice})";
                            }
                        }
                        

                        dtg_data.Refresh();
                    }


                    tcpClient.Close();
                }
                MessageBox.Show($"Đã tải dữ liệu PLC: {cmb_function.Text} \n IP: {txb_ip.Text} Port: {txb_port.Text}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_writealldataplc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Bạn có muốn lưu dữ liệu xuống PLC: {cmb_function.Text} \n IP: {txb_ip.Text} Port: {txb_port.Text}","THông báo",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string index;
                try
                {
                    using (TcpClient tcpClient = new TcpClient())
                    {
                        tcpClient.Connect(IPAddress.Parse(mcip), mcport);
                        if (dtg_data.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtg_data.Rows.Count; i++)
                            {
                                for (int j = 0; j < listdt.Count; j++)
                                {
                                    if (listdt[j].DataType == "DEC")
                                    {
                                        var a = dtg_data.Rows[i].Cells[j + 1].Value;
                                        writeint(tcpClient, listdt[j].DeviceType, listdt[j].StartDevice + listdt[j].LenghtDevice * i, dtg_data.Rows[i].Cells[j + 1].Value == null ? 0 : Convert.ToInt32(dtg_data.Rows[i].Cells[j + 1].Value.ToString()));

                                    }
                                    else if (listdt[j].DataType == "Float")
                                    {
                                        writefloat(tcpClient, listdt[j].DeviceType, listdt[j].StartDevice + listdt[j].LenghtDevice * i, dtg_data.Rows[i].Cells[j + 1].Value == null ? 0 : float.Parse(dtg_data.Rows[i].Cells[j + 1].Value.ToString()));

                                    }

                                    else
                                    {
                                        writeword(tcpClient, listdt[j].DeviceType, listdt[j].StartDevice + listdt[j].LenghtDevice * i, listdt[j].LenghtDevice, dtg_data.Rows[i].Cells[j + 1].Value.ToString());

                                    }


                                }

                            }
                        }
                        tcpClient.Close();
                    }
                    MessageBox.Show("Ghi dữ liệu xuống PLC thành công");

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
        }

       
        private void dtg_data_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (dtg_data.Rows.Count == totalcode)
            {
                dtg_data.AllowUserToAddRows = false;

            }
        }
        public string readASCII(TcpClient client, string Devicestr, int HeaderDeviceint, int NumberofDeviceint)
        {
            byte[] buffreadASCII = new byte[100];
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
                    NetworkStream stream = client.GetStream(); 
                    Array.Clear(buffreadASCII, 0, buffreadASCII.Length);
                    stream = client.GetStream();
                    stream.Write(finalcmd, 0, finalcmd.Length);
                    stream.Read(buffreadASCII, 0, buffreadASCII.Length);
                    if (buffreadASCII[9] == 0 && buffreadASCII[10] == 0)
                    {
                        return Encoding.ASCII.GetString(buffreadASCII, 10, 80).Trim('\0');
                    }
                }
            }
            return null;
        }
        public int? readDEC(TcpClient client, string Devicestr, int HeaderDeviceint)
        {
            byte[] buffreadDEC = new byte[100];
            byte[] finalcmd = new byte[21];
            byte[] pathcmd = { 0x50, 0x00, 0x00, 0xff, 0xff, 0x03, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x01, 0x04, 0x00, 0x00 };
            byte[] HeaderDevice = BitConverter.GetBytes(HeaderDeviceint);
            byte[] Device = Converttextdevicetohexdevice(Devicestr);
            byte[] NumberofDevice = BitConverter.GetBytes(2);
            Buffer.BlockCopy(pathcmd, 0, finalcmd, 0, pathcmd.Length);
            Buffer.BlockCopy(HeaderDevice, 0, finalcmd, pathcmd.Length, 3);
            Buffer.BlockCopy(Device, 0, finalcmd, pathcmd.Length + 3, 1);
            Buffer.BlockCopy(NumberofDevice, 0, finalcmd, pathcmd.Length + 4, 2);
            if (client != null)
            {
                if (client.Connected)
                {
                    NetworkStream stream = client.GetStream();
                    Array.Clear(buffreadDEC, 0, buffreadDEC.Length);
                    stream = client.GetStream();
                    stream.Write(finalcmd, 0, finalcmd.Length);
                    stream.Read(buffreadDEC, 0, buffreadDEC.Length);
                    if (buffreadDEC[9] == 0 && buffreadDEC[10] == 0)
                    {
                        byte[] buff1 = new byte[] { buffreadDEC[11], buffreadDEC[12], buffreadDEC[13], buffreadDEC[14] };
                        int Dec = BitConverter.ToInt32(buff1, 0);
                        return Dec;
                    }
                }
            }
            return null;
        }
        public float? readFloat(TcpClient client, string Devicestr, int HeaderDeviceint)
        {
            byte[] buffreadfloat = new byte[100];
            byte[] finalcmd = new byte[21];
            byte[] pathcmd = { 0x50, 0x00, 0x00, 0xff, 0xff, 0x03, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x01, 0x04, 0x00, 0x00 };
            byte[] HeaderDevice = BitConverter.GetBytes(HeaderDeviceint);
            byte[] Device = Converttextdevicetohexdevice(Devicestr);
            byte[] NumberofDevice = BitConverter.GetBytes(2);
            Buffer.BlockCopy(pathcmd, 0, finalcmd, 0, pathcmd.Length);
            Buffer.BlockCopy(HeaderDevice, 0, finalcmd, pathcmd.Length, 3);
            Buffer.BlockCopy(Device, 0, finalcmd, pathcmd.Length + 3, 1);
            Buffer.BlockCopy(NumberofDevice, 0, finalcmd, pathcmd.Length + 4, 2);
            if (client != null)
            {
                if (client.Connected)
                {
                    NetworkStream stream = client.GetStream();
                    Array.Clear(buffreadfloat, 0, buffreadfloat.Length);
                    stream = client.GetStream();
                    stream.Write(finalcmd, 0, finalcmd.Length);
                    stream.Read(buffreadfloat, 0, buffreadfloat.Length);
                    if (buffreadfloat[9] == 0 && buffreadfloat[10] == 0)
                    {
                        byte[] buff1 = new byte[] { buffreadfloat[11], buffreadfloat[12], buffreadfloat[13], buffreadfloat[14] };
                        float fl = BitConverter.ToSingle(buff1, 0);
                        return fl;
                    }
                }
            }
            return null;
        }
        public void writeword(TcpClient client, string Devicestr, int HeaderDeviceint, int NumberofDeviceint, string datawrite)
        {
            StringBuilder strb = new StringBuilder();
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
                int lenghtdatawrite = datawrite.Length;
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
                    NetworkStream stream = client.GetStream();
                    stream.Write(finalcmd, 0, finalcmd.Length);
                    byte[] buff = new byte[100];
                    stream.Read(buff, 0, buff.Length);
                    Array.Clear(buff, 0, buff.Length);
                }
            }

        }
        public void writeint(TcpClient client, string Devicestr, int HeaderDeviceint, int datawrite)
        {
            StringBuilder strb = new StringBuilder();
            byte[] pathcmd1 = { 0x50, 0x00, 0x00, 0xff, 0xff, 0x03, 0x00 };
            byte[] pathcmd3 = { 0x00, 0x00, 0x01, 0x14, 0x00, 0x00 };
            byte[] HeaderDevice = BitConverter.GetBytes(HeaderDeviceint);
            byte[] Device = Converttextdevicetohexdevice(Devicestr);
            byte[] NumberofDevice = BitConverter.GetBytes(2);
            byte[] datawritetoplc;
            datawritetoplc = BitConverter.GetBytes(datawrite);
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
                    NetworkStream stream = client.GetStream();
                    stream.Write(finalcmd, 0, finalcmd.Length);
                    byte[] buff = new byte[100];
                    stream.Read(buff, 0, buff.Length);
                    Array.Clear(buff, 0, buff.Length);
                }
            }

        }
        public void writefloat(TcpClient client, string Devicestr, int HeaderDeviceint, float datawrite)
        {
            StringBuilder strb = new StringBuilder();
            byte[] pathcmd1 = { 0x50, 0x00, 0x00, 0xff, 0xff, 0x03, 0x00 };
            byte[] pathcmd3 = { 0x00, 0x00, 0x01, 0x14, 0x00, 0x00 };
            byte[] HeaderDevice = BitConverter.GetBytes(HeaderDeviceint);
            byte[] Device = Converttextdevicetohexdevice(Devicestr);
            byte[] NumberofDevice = BitConverter.GetBytes(2);
            byte[] datawritetoplc;
            datawritetoplc = BitConverter.GetBytes(datawrite);
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
                    NetworkStream stream = client.GetStream();
                    stream.Write(finalcmd, 0, finalcmd.Length);
                    byte[] buff = new byte[100];
                    stream.Read(buff, 0, buff.Length);
                    Array.Clear(buff, 0, buff.Length);
                }
            }

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

        private void btn_readselect_Click(object sender, EventArgs e)
        {

            if (dtg_data.SelectedRows.Count > 0)
            {
                try
                {
                    for (int i = 0; i < dtg_data.SelectedRows.Count; i++)
                    {
                        DataGridViewRow slt = dtg_data.SelectedRows[i];
                        if (!slt.IsNewRow)
                        {
                            int index = slt.Index;

                            using (TcpClient tcpClient = new TcpClient())
                            {
                                tcpClient.Connect(IPAddress.Parse(mcip), mcport);
                                if (dtg_data.Rows.Count > 0)
                                {
                                    for (int j = 0; j < listdt.Count; j++)
                                    {
                                        if (listdt[j].DataType == "DEC")
                                        {

                                            dtg_data.Rows[index].Cells[j + 1].Value = readDEC(tcpClient, listdt[j].DeviceType, listdt[j].StartDevice + listdt[j].LenghtDevice * index);

                                        }
                                        else if (listdt[j].DataType == "Float")
                                        {
                                            dtg_data.Rows[index].Cells[j + 1].Value = readFloat(tcpClient, listdt[j].DeviceType, listdt[j].StartDevice + listdt[j].LenghtDevice * index);

                                        }

                                        else
                                        {
                                            dtg_data.Rows[index].Cells[j + 1].Value = readASCII(tcpClient, listdt[j].DeviceType, listdt[j].StartDevice + listdt[j].LenghtDevice * index, listdt[j].LenghtDevice);

                                        }
                                    }

                                }
                                tcpClient.Close();
                            }

                           



                        }
                    }
                    MessageBox.Show("Tải dữ liệu PLC thành công");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                


            }
            else
            {
                MessageBox.Show("Hãy chọn hàng muốn tải dữ liệu");
            }

        }

        private void btn_writeselect_Click(object sender, EventArgs e)
        {
            if (dtg_data.SelectedRows.Count > 0)
            {
                try
                {
                    for (int i = 0; i < dtg_data.SelectedRows.Count; i++)
                    {
                        DataGridViewRow slt = dtg_data.SelectedRows[i];
                        if (!slt.IsNewRow)
                        {
                            int index = slt.Index;
                            using (TcpClient tcpClient = new TcpClient())
                            {
                                tcpClient.Connect(IPAddress.Parse(mcip), mcport);
                                if (dtg_data.Rows.Count > 0)
                                {
                                    for (int j = 0; j < listdt.Count; j++)
                                    {
                                        if (listdt[j].DataType == "DEC")
                                        {

                                            writeint(tcpClient, listdt[j].DeviceType, listdt[j].StartDevice + listdt[j].LenghtDevice * index, dtg_data.Rows[index].Cells[j + 1].Value == null ? 0 : Convert.ToInt32(dtg_data.Rows[index].Cells[j + 1].Value.ToString()));

                                        }
                                        else if (listdt[j].DataType == "Float")
                                        {
                                            writefloat(tcpClient, listdt[j].DeviceType, listdt[j].StartDevice + listdt[j].LenghtDevice * index, dtg_data.Rows[index].Cells[j + 1].Value == null ? 0 : float.Parse(dtg_data.Rows[index].Cells[j + 1].Value.ToString()));

                                        }

                                        else
                                        {
                                            writeword(tcpClient, listdt[j].DeviceType, listdt[j].StartDevice + listdt[j].LenghtDevice * index, listdt[j].LenghtDevice, dtg_data.Rows[index].Cells[j + 1].Value.ToString());

                                        }


                                    }

                                }
                                tcpClient.Close();
                            }
                           


                        }
                    }
                    MessageBox.Show("Ghi dữ liệu xuống PLC thành công");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                


            }
            else
            {
                MessageBox.Show("Hãy chọn hàng muốn ghi dữ liệu xuống PLC");
            }
        }
        private ToolTip cellToolTip = new ToolTip();

        private void dtg_data_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 1) 
            {
                    string infor = $"{listdt[e.ColumnIndex - 1].DeviceType}{listdt[e.ColumnIndex - 1].LenghtDevice*e.RowIndex+ listdt[e.ColumnIndex - 1].StartDevice}";
                    cellToolTip.SetToolTip(dtg_data,infor);
            }
        }

        private void dtg_data_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            cellToolTip.Hide(dtg_data);
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < listdt.Count; i++)
            {
                if (listdt[i].DataType == "DEC")
                {
                    dt.Columns.Add(listdt[i].namepart, typeof(int));
                }
                else if(listdt[i].DataType == "Float")
                {
                    dt.Columns.Add(listdt[i].namepart, typeof(float));

                }
                else
                {
                    dt.Columns.Add(listdt[i].namepart, typeof(string));
                }
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV Files|*.csv";
            ofd.Title = "Open CSV File";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string namefile = ofd.FileName;
                string[] datacsv = File.ReadAllLines(namefile);
                for (int i = 1; i <= totalcode; i++)
                {
                    object[] rowcsv = datacsv[i].TrimEnd(',').Split(',');
                    object[] rowdtg = rowcsv.Skip(1).ToArray();
                    dt.Rows.Add(rowdtg);
                }
                dtg_data.DataSource = dt;
                if (!dtg_data.Columns.Contains("STT"))
                {
                    DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn();
                    sttColumn.HeaderText = "STT";
                    sttColumn.Name = "STT";
                    dtg_data.Columns.Insert(0, sttColumn);
                    dtg_data.Columns[0].Width = 60;
                }
                for (int i = 0; i < dtg_data.Rows.Count; i++)
                {
                    dtg_data.Rows[i].Cells["STT"].Value = (i + 1).ToString();
                }
                if (!dtg_data.Columns[2].HeaderText.Contains("("))
                {
                    for (int i = 1; i <= listdt.Count; i++)
                    {
                        string strh = dtg_data.Columns[i].HeaderText;
                        dtg_data.Columns[i].HeaderText = strh + $" ({listdt[i - 1].DeviceType}{listdt[i - 1].StartDevice} - {listdt[i - 1].DeviceType}{listdt[i - 1].LenghtDevice * totalcode + listdt[i - 1].StartDevice})";
                    }
                }
                dtg_data.Refresh();
            }
            

        }
        private void SearchInDataGridView(string searchText)
        {
            
            foreach (DataGridViewRow row in dtg_data.Rows)
            {
                

                
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex > 0 && cell.Value != null && txb_search.Text != "" &&  cell.Value.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                    {

                        cell.Style.BackColor = Color.Green;
                    }
                    else
                    {
                        cell.Style.BackColor = Color.White;
                    }
                    
                }

                
                
            }
        }

        private void txb_search_TextChanged(object sender, EventArgs e)
        {
            //if (txb_search.Text != "")
            //{
                SearchInDataGridView(txb_search.Text);
            //}
            //else
            //{
            //    dtg_data.DefaultCellStyle.BackColor = Color.Red;
            //}
               
            
            
        }

        private void btn_testconnect_Click(object sender, EventArgs e)
        {
            try
            {

                using (TcpClient tcpClient = new TcpClient())
                {
                    tcpClient.Connect(IPAddress.Parse(mcip), mcport);
                    if (tcpClient.Connected)
                    {
                        MessageBox.Show("Kết nối thành công");
                    }
                    else
                    {
                        MessageBox.Show("Kết nối thất bại");
                    }

                    tcpClient.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeManagerment
{
    public class datamaster
    {
        public string address { get; set; }
        public string namepart { get; set; }
        public string DeviceType { get; set; }
        public int StartDevice { get; set; }
        public string DataType { get; set; }
        public int LenghtDevice { get; set; }
        public int TotalCode { get; set; }
        public int index { get; set; }

        public datamaster(string address,string namepart, string devicetype,int startdevice,string datatype,int lenghtdevice,int totalcode,int index) { 
            this.address = address;
            this.namepart = namepart;
            this.DeviceType = devicetype;
            this.StartDevice = startdevice;
            this.DataType = datatype;
            this.LenghtDevice = lenghtdevice;
            this.TotalCode = totalcode;
            this.index = index;
        }
        public datamaster( string namepart, string devicetype, int startdevice, string datatype, int lenghtdevice, int index)
        {
            
            this.namepart = namepart;
            this.DeviceType = devicetype;
            this.StartDevice = startdevice;
            this.DataType = datatype;
            this.LenghtDevice = lenghtdevice;
            this.index = index;
        }

    }
}

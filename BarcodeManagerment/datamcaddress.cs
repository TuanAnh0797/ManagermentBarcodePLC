using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeManagerment
{
    public class datamcaddress
    {
        public string Namemachine { get;set; }
        public string Address { get;set; }
        public int portnumber { get;set; }

        public datamcaddress(string nammachine, string ip, int portnumber)
        {
            this.Namemachine = nammachine;
            this.Address = ip;
            this.portnumber = portnumber;
        }
    }
}

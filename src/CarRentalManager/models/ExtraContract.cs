using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarRentalManager.models
{
    public class ExtraContract: Contract
    {
        private string customerName;
        public string CustomerName { get { return customerName; } set { customerName = value.Trim(); } }
        public string CustomerPhone { get; set; }
        public string CustomerIdCard { get; set; }
        public ExtraContract(): base() { }
    }
}

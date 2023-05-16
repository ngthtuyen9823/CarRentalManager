using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManager.models
{
    public class ExtraOrder : Order
    {
        private string customerName;
        private string carName;
        public string CustomerIdCard { get; set; }
        public string CustomerName { get { return customerName; } set { customerName = value.Trim(); } }
        public string CarName { get { return carName; } set { carName = value.Trim(); } }
        public ExtraOrder() : base() { }
    }
}

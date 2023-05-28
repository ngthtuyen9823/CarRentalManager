using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManager.models
{
    public class ExtraOrder : Order
    {
        public string CustomerIdCard { get; set; }
        public string CustomerName { get; set; }
        public string CarName { get; set; }
        public ExtraOrder() : base() { }
    }
}

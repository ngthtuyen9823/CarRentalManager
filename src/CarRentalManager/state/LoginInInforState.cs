using CarRentalManager.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManager.state
{
    public static class LoginInInforState
    {
        public static int ID { get; set; }
        public static string Name { get; set; }
        public static EUserRole Role { get; set; }
    }
}

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
        public static bool isLogin;

        public static void setState(int id, string name, EUserRole role)
        {
            ID = id;
            Name = name;
            Role = role;
            if(name != null && id.ToString() != null)
                isLogin = true;
        }

        public static void logOut()
        {
            isLogin = false;
        }
    }
}

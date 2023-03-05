using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManager.services
{
    public class UserService
    {
        public UserService() { }

        public static void signUp(string email, string password)
        {
            try
            {
                string queryString = SqlQueryService.getUserWithEmail(email);
            }
            catch(Exception exc) {
               MessageBox.Show("services/User.service.cs", exc.Message);
            }
        }
    }
}

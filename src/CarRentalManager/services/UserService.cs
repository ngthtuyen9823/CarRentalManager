using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalManager.enums;

namespace CarRentalManager.services
{
    public class UserService
    {
        readonly SqlQueryService sqlQueryService = new SqlQueryService();
        public UserService() { }

        public void signUp(string email, string password)
        {
            try
            {
                string queryString = sqlQueryService.getCreadentialWithEmail(ETableName.USER, email);
            }
            catch(Exception exc) {
               MessageBox.Show("services/User.service.cs", exc.Message);
            }
        }
    }
}

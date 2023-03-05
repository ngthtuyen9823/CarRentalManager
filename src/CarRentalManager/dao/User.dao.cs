using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalManager.modals;
using CarRentalManager.services;

namespace CarRentalManager.dao
{
    public class UserDao
    {
        public UserDao() { }

        public static User getUserWithEmail(string email)
        {
            string queryString = SqlQueryService.getUserWithEmail(email);
            //*TODO: Update call database later
            return null;
        } 
    }
}

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
        readonly SqlQueryService sqlQueryService = new SqlQueryService();
        public UserDao() { }

        public User getUserWithEmail(string email)
        {
            string queryString = sqlQueryService.getUserWithEmail(email);
            //*TODO: Update call database later
            return null;
        } 
    }
}

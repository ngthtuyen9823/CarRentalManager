using System;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;

using CarRentalManager.services;

namespace CarRentalManager.dao
{
    public class UserDAO
    {
        public UserDAO() { }

        public User getInforByEmail(string email)
        {
            using (var db = new CRMContext())
            {
                return db.Users.FirstOrDefault(user => user.email == email);
            }
        } 
    }
}

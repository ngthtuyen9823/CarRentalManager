﻿using System.Linq;
using CarRentalManager.services;

namespace CarRentalManager.dao
{
    public class UserDAO
    {
        readonly Context db = new Context();
        public UserDAO() { }

        public User getInforByEmail(string email)
        {
            return db.Users.FirstOrDefault(user => user.Email == email);
        }
    }
}

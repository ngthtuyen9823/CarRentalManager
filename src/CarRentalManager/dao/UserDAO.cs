﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using CarRentalManager.enums;
using CarRentalManager.models;
using CarRentalManager.services;

namespace CarRentalManager.dao
{
    public class UserDAO
    {
        readonly SqlQueryService sqlService = new SqlQueryService();
        readonly CommondDataService commondDataService = new CommondDataService();
        readonly DbConnectionDAO dbConnectionDAO = new DbConnectionDAO();
        readonly Context db = new Context();
        public UserDAO() { }

        public User getInforByEmail(string email)
        {
            return db.Users.SingleOrDefault(s => s.Email == email);
        } 
    }
}

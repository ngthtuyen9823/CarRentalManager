using CarRentalManager.enums;
using CarRentalManager.services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CarRentalManager.models;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using MaterialDesignThemes.Wpf;
using System.Net;
using System.Xml.Linq;
using System.Data.SqlTypes;
using System.Data.Entity.Migrations;

namespace CarRentalManager.dao
{
    public class CustomerDAO
    {
        readonly Context db = new Context();

        public CustomerDAO() { }

        public List<Customer> getListCustomer()
        {
            return db.Customers.ToList();
        }

        public void createCustomer(Customer newCustomer)
        {
            db.Customers.Add(newCustomer);
            db.SaveChanges();
        }

        public void removeCustomer(int id)
        {
            var customer = db.Customers.FirstOrDefault(c => c.id == id);
            db.Customers.Remove(customer);
            db.SaveChanges();
        }

        public Customer getCustomerById(string id)
        {
            return db.Customers.FirstOrDefault(customer => customer.id.ToString() == id);
        }

        public void updateCustomer(Customer customer)
        {
            db.Customers.AddOrUpdate(customer);
            db.SaveChanges();
        }
        public Customer getCustomerByIdCard(string idCard)
        {
            return db.Customers.FirstOrDefault(customer => customer.idCard.ToString() == idCard);
        }
    }
}

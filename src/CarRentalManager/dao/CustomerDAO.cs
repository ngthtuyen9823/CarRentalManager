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
        public CustomerDAO() { }

        public List<Customer> getListCustomer()
        {
            using (var db = new CRMContext())
            {
                return db.Customers.ToList();
            }
        }

        public void createCustomer(Customer newCustomer)
        {
            using (var db = new CRMContext())
            {
                db.Customers.Add(newCustomer);
                db.SaveChanges();
            }
        }

        public void removeCustomer(int id)
        {
            using (var db = new CRMContext())
            {
                var customer = db.Customers.Find(id);
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
        }

        public Customer getCustomerById(string id)
        {
            using (var db = new CRMContext())
            {
                return db.Customers.Find(id);
            }
        }

        public void updateCustomer(Customer customer)
        {
            using (var db = new CRMContext())
            {
                db.Customers.AddOrUpdate(customer);
                db.SaveChanges();
            }
        }
        public Customer getCustomerByIdCard(string idCard)
        {
            string sqlStringGetTable = sqlService.getValueByIdCard(idCard,ETableName.CUSTOMER);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return commondDataService.dataTableToList<Customer>(dataTable)?.First();
        }

        public Customer getCustomerByCondition(string condition) {
            string sqlStringGetTable = sqlService.getCustomerByCondition(condition);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return commondDataService.dataTableToList<Customer>(dataTable)?.First();
        }
    }
}

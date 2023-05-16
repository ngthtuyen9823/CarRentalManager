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

namespace CarRentalManager.dao
{
    public class CustomerDAO
    {
        readonly SqlQueryService sqlService = new SqlQueryService();
        readonly CommondDataService commondDataService = new CommondDataService();
        readonly DbConnectionDAO dbConnectionDAO = new DbConnectionDAO();

        public CustomerDAO() { }

        public List<Customer> getListCustomer()
        {
            string sqlStringGetTable = sqlService.getListTableData(ETableName.CUSTOMER);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return commondDataService.dataTableToList<Customer>(dataTable);
        }

        public void createCustomer(Customer newCustomer)
        {
            string sqlString = sqlService.createCustomer(newCustomer);
            dbConnectionDAO.getDataTable(sqlString);
        }

        public void removeCustomer(int id)
        {
            string sqlString = sqlService.removeById(ETableName.CUSTOMER, id);
            dbConnectionDAO.getDataTable(sqlString);
        }
    
        public List<Customer> getListCustomerByDescOrAsc(bool isDescrease, string fieldName)
        {
            string sqlStringGetTable = sqlService.getSortByDescOrAsc(isDescrease, fieldName, ETableName.CUSTOMER);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return commondDataService.dataTableToList<Customer>(dataTable);
        }

        public Customer getCustomerById(string id)
        {
            string sqlStringGetTable = sqlService.getValueById(id,ETableName.CUSTOMER);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return commondDataService.dataTableToList<Customer>(dataTable)?.First();
        }

        public void updateCustomer(Customer customer)
        {
            string sqlString = sqlService.updateCustomer(customer);
            dbConnectionDAO.getDataTable(sqlString);
        }
        public Customer getCustomerByIdCard(string idCard)
        {
            string sqlStringGetTable = sqlService.getValueByIdCard(idCard,ETableName.CUSTOMER);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return commondDataService.dataTableToList<Customer>(dataTable)?.First();
        }
    }
}

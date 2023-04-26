using CarRentalManager.enums;
using CarRentalManager.services;
using System.Collections.Generic;
using System.Data;
using CarRentalManager.models;
using System.Linq;
using System.Windows;

namespace CarRentalManager.dao
{
    public class OrderDAO
    {
        readonly SqlQueryService sqlService = new SqlQueryService();
        readonly CommondDataService commondDataService = new CommondDataService();
        readonly DbConnectionDAO dbConnectionDAO = new DbConnectionDAO();

        public OrderDAO() { }

        public List<Order> getListOrder()
        {
            string sqlStringGetTable = sqlService.getListTableData(ETableName.ORDER);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return commondDataService.dataTableToList<Order>(dataTable);
        }
        public void createOrder(Order order)
        {
            string sqlString = sqlService.createOrder(order);
            dbConnectionDAO.getDataTable(sqlString);
        }

        public List<Order> getListOrderByDescOrAsc(bool isDescrease, string fieldName)
        {
            string sqlStringGetTable = sqlService.getSortByDescOrAsc(isDescrease, fieldName, ETableName.ORDER);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return commondDataService.dataTableToList<Order>(dataTable);
        }

        public Order getOrderById(string id)
        {
            string sqlStringGetTable = sqlService.getValueById(id, ETableName.ORDER);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return commondDataService.dataTableToList<Order>(dataTable).First();
        }

        public void removeOrder(int id)
        {
            try
            {
                string sqlString = sqlService.removeById(ETableName.ORDER, id);
                dbConnectionDAO.executing(sqlString, ETableName.ORDER);
            }
            catch
            {
                throw new System.Exception();
            }
        }
        public void updateOrder(Order order)
        {
            string sqlString = sqlService.updateOrder(order);
            dbConnectionDAO.getDataTable(sqlString);
        }
        public void updateStatusOfOrder(Order order)
        {
            string sqlString = sqlService.updateStatusOfOrder(order);
            dbConnectionDAO.getDataTable(sqlString);
        }

        public List<Order> getListOrderByCondition(string condition) {
            string sqlString = sqlService.getListByCondition(ETableName.ORDER, condition);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlString);
            return commondDataService.dataTableToList<Order>(dataTable);
        }
    }
}

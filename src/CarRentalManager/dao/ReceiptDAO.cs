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

namespace CarRentalManager.dao
{
    public class ReceiptDAO
    {
        readonly SqlQueryService sqlService = new SqlQueryService();
        readonly CommondDataService commondDataService = new CommondDataService();
        readonly DbConnectionDAO dbConnectionDAO = new DbConnectionDAO();

        public ReceiptDAO() { }

        public List<Receipt> getListReceipt()
        {
            string sqlStringGetTable = sqlService.getListTableData(ETableName.RECEIPT);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return commondDataService.dataTableToList<Receipt>(dataTable);
        }

        public List<Receipt> getListReceiptByDescOrAsc(bool isDescrease, string fieldName)
        {
            string sqlStringGetTable = sqlService.getSortByDescOrAsc(isDescrease, fieldName, ETableName.RECEIPT);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return commondDataService.dataTableToList<Receipt>(dataTable);
        }

        public Receipt getReceiptById(string id)
        {
            
            string sqlStringGetTable = sqlService.getValueById(id, ETableName.RECEIPT);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return commondDataService.dataTableToList<Receipt>(dataTable)?.First();
        }

        public Receipt createReceipt(Receipt receipt)
        {
            string sqlStringGetTable = sqlService.createReceipt(receipt);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return commondDataService.dataTableToList<Receipt>(dataTable)?.First();
        }

        public void removeReceipt(int id)
        {
            string sqlString = sqlService.removeById(ETableName.RECEIPT, id);
            dbConnectionDAO.getDataTable(sqlString);
        }
        public void updateReceipt(Receipt receipt)
        {
            string sqlString = sqlService.updateReceipt(receipt);
            dbConnectionDAO.getDataTable(sqlString);
        }
    }
}

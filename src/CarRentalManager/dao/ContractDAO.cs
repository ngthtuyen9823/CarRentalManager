using CarRentalManager.enums;
using CarRentalManager.models;
using CarRentalManager.services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Linq;

namespace CarRentalManager.dao
{
    public class ContractDAO
    {
        readonly SqlQueryService sqlService = new SqlQueryService();
        readonly CommondDataService commondDataService = new CommondDataService();
        readonly DbConnectionDAO dbConnectionDAO = new DbConnectionDAO();
        public ContractDAO() { }

        public Contract getContractById(string id)
        {
            string sqlStringGetTable = sqlService.getValueById(id, ETableName.CONTRACT);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return commondDataService.dataTableToList<Contract>(dataTable)?.First();

        }
        public void createContract(Contract newContract)
        {
            string sqlString = sqlService.createNewContract(newContract);
            dbConnectionDAO.getDataTable(sqlString);
        }

        public void removeContract(int id)
        {
            string sqlString = sqlService.removeById(ETableName.CONTRACT, id);
            dbConnectionDAO.getDataTable(sqlString);
        }
        public void updateContract(Contract updatedContract)
        {
            string sqlString = sqlService.updateContract(updatedContract);
            dbConnectionDAO.executing(sqlString, ETableName.CONTRACT);
        }

        public List<Contract> getListContract()
        {
            string sqlStringGetTable = sqlService.getListTableData(ETableName.CONTRACT);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return commondDataService.dataTableToList<Contract>(dataTable);
        }
        public List<Contract> getSupplierListContract(List<int> orderId)
        {
            DataTable dataTable = new DataTable();  
            foreach (int id in orderId)
            {
                string sqlStringGetTable = sqlService.getListTableDataByOrderId(id, ETableName.CONTRACT);
                DataTable tempDatatable = dbConnectionDAO.getDataTable(sqlStringGetTable);
                dataTable.Merge(tempDatatable);
            }
            return commondDataService.dataTableToList<Contract>(dataTable);
        }
        public List<Contract> getListContractByDescOrAsc(bool isDescrease, string fieldName)
        {
            string sqlStringGetTable = sqlService.getSortByDescOrAsc(isDescrease, fieldName, ETableName.CONTRACT);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return commondDataService.dataTableToList<Contract>(dataTable);
        }
        public List<Contract> getListByCondition(string condition)
        {
            string sqlString = sqlService.getListByCondition(ETableName.CONTRACT, condition);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlString);
            return commondDataService.dataTableToList<Contract>(dataTable);
        }
    }
}


using CarRentalManager.enums;
using CarRentalManager.services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Linq;
using System.Data.Entity.Migrations;
using System.Linq.Dynamic.Core;

namespace CarRentalManager.dao
{
    public class ContractDAO
    {
        public ContractDAO() { }

        public Contract getContractById(string id)
        {
            using (var db = new CRMContext())
            {
                return db.Contracts.Find(id);
            }
        }
        public void createContract(Contract newContract)
        {
            using (var db = new CRMContext())
            {
                db.Contracts.Add(newContract);
                db.SaveChanges();
            }
        }

        public void removeContract(int id)
        {
            using (var db = new CRMContext())
            {
                var contract = db.Contracts.Find(id);
                db.Contracts.Remove(contract);
                db.SaveChanges();
            }
        }
        public void updateContract(Contract updatedContract)
        {
            using (var db = new CRMContext())
            {
                db.Contracts.AddOrUpdate(updatedContract);
            }
        }

        public List<Contract> getListContract()
        {
            using (var db = new CRMContext())
            {
                return db.Contracts.ToList();
            }
        }
        public List<ExtraContract> getListContractByOrderId(List<int> orderId)
        {
            DataTable dataTable = new DataTable();  
            foreach (int id in orderId)
            {
                string sqlStringGetTable = sqlService.getListTableDataByOrderId(id, ETableName.CONTRACT);
                DataTable tempDatatable = dbConnectionDAO.getDataTable(sqlStringGetTable);
                dataTable.Merge(tempDatatable);
            }
            return commondDataService.dataTableToList<ExtraContract>(dataTable);
        }

        public List<ExtraContract> getListExtraContract()
        {
            string sqlStringGetTable = sqlService.getListExtraContract();
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return commondDataService.dataTableToList<ExtraContract>(dataTable);
        }

        public List<Contract> getListContractByDescOrAsc(bool isDescrease, string fieldName)
        {
            string sqlStringGetTable = sqlService.getSortByDescOrAsc(isDescrease, fieldName, ETableName.CONTRACT);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return commondDataService.dataTableToList<Contract>(dataTable);
        }
        public List<Contract> getListByCondition(string condition)
        {
            using (var db = new CRMContext())
            {
                return db.Contracts.Where(condition).ToList();
            }
        }
    }
}


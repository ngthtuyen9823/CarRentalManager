using CarRentalManager.enums;
using CarRentalManager.services;
using System.Collections.Generic;
using System.Data;
using CarRentalManager.models;
using System.Windows;

namespace CarRentalManager.dao
{
    public class SupplierDAO
    {
        readonly SqlQueryService sqlService = new SqlQueryService();
        readonly CommondDataService commondDataService = new CommondDataService();
        readonly DbConnectionDAO dbConnectionDAO = new DbConnectionDAO();
        public SupplierDAO() { }

        public List<Supplier> getListSupplier()
        {
            string sqlStringGetTable = sqlService.getListTableData(ETableName.SUPPLIER);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return commondDataService.dataTableToList<Supplier>(dataTable);
        }

        public void createSupplier(Supplier supplier)
        {
            string sqlString = sqlService.createSupplier(supplier);
            dbConnectionDAO.getDataTable(sqlString);
        }
        public void removeSupplier(int id)
        {
            string sqlString = sqlService.removeById(ETableName.SUPPLIER, id);
            dbConnectionDAO.getDataTable(sqlString);
        }
        public void updatSupplier(Supplier supplier)
        {
            string sqlString = sqlService.updateSupplier(supplier);
            dbConnectionDAO.getDataTable(sqlString);
        }
    }
}

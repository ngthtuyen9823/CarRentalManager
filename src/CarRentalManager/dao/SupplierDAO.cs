using CarRentalManager.enums;
using CarRentalManager.services;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Linq;

namespace CarRentalManager.dao
{
    public class SupplierDAO
    {
        public SupplierDAO() { }

        public List<Supplier> getListSupplier()
        {
            using (var db = new CRMContext())
            {
                return db.Suppliers.ToList();
            }
        }

        public void createSupplier(Supplier supplier)
        {
            using (var db = new CRMContext())
            {
                db.Suppliers.Add(supplier);
                db.SaveChanges();
            }
        }
        public void removeSupplier(int id)
        {
            using (var db = new CRMContext())
            {
                var supplier = db.Suppliers.FirstOrDefault(s => s.id == id);
                db.Suppliers.Remove(supplier);
                db.SaveChanges();
            }
        }
        public void updatSupplier(Supplier supplier)
        {
            using (var db = new CRMContext())
            {
                db.Suppliers.AddOrUpdate(supplier);
                db.SaveChanges();
            }
        }
        public Supplier getInforByEmail(string email)
        {
            string sqlStringGetTable = sqlService.getCreadentialWithEmail(ETableName.SUPPLIER, email);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return commondDataService.dataTableToList<Supplier>(dataTable)?.First();
        }
    }
}

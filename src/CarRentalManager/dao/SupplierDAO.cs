using CarRentalManager.enums;
using CarRentalManager.services;
using System.Collections.Generic;
using System.Data;
using CarRentalManager.models;
using System.Windows;
using System.Linq;
using System.Data.Entity.Migrations;

namespace CarRentalManager.dao
{
    public class SupplierDAO
    {
        readonly Context db =  new Context();
        public SupplierDAO() { }

        public List<Supplier> getListSupplier()
        {
            return db.Suppliers.ToList();
        }

        public void createSupplier(Supplier supplier)
        {
            db.Suppliers.Add(supplier);
            db.SaveChanges();
        }
        public void removeSupplier(int id)
        {
            var supplier = db.Suppliers.FirstOrDefault(s => s.id == id);
            db.Suppliers.Remove(supplier);
            db.SaveChanges();
        }
        public void updatSupplier(Supplier supplier)
        {
            db.Suppliers.AddOrUpdate(supplier);
            db.SaveChanges();
        }
        public Supplier getInforByEmail(string email)
        {
            return db.Suppliers.FirstOrDefault(supplier => supplier.email == email);
        }
    }
}

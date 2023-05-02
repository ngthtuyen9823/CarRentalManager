using CarRentalManager.enums;
using CarRentalManager.services;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System;
using System.Linq.Dynamic.Core;
using System.Windows.Documents;
using MaterialDesignThemes.Wpf;

namespace CarRentalManager.dao
{
    public class CarDAO
    {
        public CarDAO() { }

        public List<Car> getListCar()
        {
            using (var db = new CRMContext())
            {
                return db.Cars.ToList();
            }
        }
        public List<Car> getSupplierListCar(string supplierId)
        {
            string sqlStringGetTable = sqlService.getListTableDataBySupplierId(supplierId, ETableName.CAR);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return commondDataService.dataTableToList<Car>(dataTable);
        }
        public void createCar(Car newCar)
        {
            using (var db = new CRMContext())
            {
                db.Cars.Add(newCar);
                db.SaveChanges();
            }
        }
        public void updateCar(Car updatedCar)
        {
            using (var db = new CRMContext())
            {
                db.Cars.AddOrUpdate(updatedCar);
                db.SaveChanges();
            }
        }

        public void removeCar(int id)
        {
            using (var db = new CRMContext())
            {
                var entityToRemove = db.Cars.Find(id);
                if (entityToRemove != null)
                {
                    db.Cars.Remove(entityToRemove);
                    db.SaveChanges();
                }
            }
        }

        public List<Car> getListCarByDescOrAsc(bool isDescrease, string fieldName)
        {
            using (var db = new CRMContext())
            {
                var orderByMethod = isDescrease ? "OrderByDescending" : "OrderBy";
                return  db.Cars.AsQueryable().OrderBy($"{fieldName} {orderByMethod}").ToList();
            }
        }

        public Car getCarById(string id)
        {
            string sqlStringGetTable = sqlService.getValueById(id, ETableName.CAR);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return commondDataService.dataTableToList<Car>(dataTable).First();
        }

        public List<Car> getListCarByType(ECarType eCarType)
        {
            using (var db = new CRMContext())
            {
                return db.Cars.Where(c => c.type == eCarType.ToString()).ToList();
            }
        }
        public List<Car> getListByRange(int fromPrice, int toPrice)
        {
            using (var db = new CRMContext())
            {
                return db.Cars.Where(c => c.price >= fromPrice && c.price < toPrice).ToList();
            }
        }
        public List<string> getListCarBrand(string fieldName)
        {
            using (var db = new CRMContext())
            {
                return db.Cars.Select(c => (string)c.GetType().GetProperty(fieldName).GetValue(c)).Distinct().ToList();
            }
        }
        public List<Car> getListCarByCondition(string City, string Brand, int Seats, DateTime Start, DateTime End)
        {
            try
            {
                string sqlStringGetTable = sqlService.getListCarByCondition(City, Brand, Seats, Start, End);
                DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
                if (dataTable?.Rows?.Count != 0)
                    return commondDataService.dataTableToList<Car>(dataTable);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public bool checkIsAvailable(DateTime start, DateTime end, int carId)
        {
            string sqlStringGetTable = sqlService.checkIsAvailable(start, end, carId);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return (int)dataTable.Rows[0][0] == 1;
        }

    }
}

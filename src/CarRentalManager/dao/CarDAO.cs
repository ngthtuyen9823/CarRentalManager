using CarRentalManager.enums;
using CarRentalManager.services;
using System.Collections.Generic;
using System.Data;
using CarRentalManager.models;
using System.Linq;
using System.Windows;
using System;
using System.Windows.Input;
using System.Linq.Dynamic.Core;
using MaterialDesignThemes.Wpf;
using System.Data.Entity;

namespace CarRentalManager.dao
{
    public class CarDAO
    {
        readonly SqlQueryService sqlService = new SqlQueryService();
        readonly CommondDataService commondDataService = new CommondDataService();
        readonly DbConnectionDAO dbConnectionDAO = new DbConnectionDAO();
        readonly Context db = new Context();
        public CarDAO() { }

        public List<Car> getListCar()
        {
            return db.Cars.ToList();
        }
        public List<Car> getSupplierListCar(string supplierId)
        {
            var listCar = (from car in db.Cars
                           where (car.SupplierId.ToString() == supplierId)
                           select car).ToList();
            return listCar;
        }
        public void createCar(Car newCar)
        {
            db.Cars.Add(newCar);
            db.SaveChanges();
        }
        public void updateCar(Car updatedCar)
        {
            Car foundCar = db.Cars.Single(car => car.ID == updatedCar.ID);
            updatedCar.UpdatedAt = DateTime.Now;
            foundCar = updatedCar;
            db.SaveChanges();
        }

        public void removeCar(int id)
        {
            Car foundCar = db.Cars.Single(car => car.ID == id);
            db.Cars.Remove(foundCar);
            db.SaveChanges();
        }

        public List<Car> getListCarByDescOrAsc(bool isDescrease, string fieldName)
        {
            var orderByMethod = isDescrease ? "OrderByDescending" : "OrderBy";
            return db.Cars.AsQueryable().OrderBy($"{fieldName} {orderByMethod}").ToList();
        }

        public Car getCarById(string id)
        {
            return db.Cars.Single(car => car.ID.ToString() == id);
        }

        public List<Car> getListCarByType(ECarType eCarType)
        {
            return db.Cars.Where(c => c.Type == eCarType.ToString()).ToList();
        }
        public List<Car> getListByRange(int fromPrice, int toPrice)
        {
            return db.Cars.Where(c => c.Price >= fromPrice && c.Price < toPrice).ToList();
        }
        public List<string> getListCarBrand(string fieldName)
        {
            return db.Cars.Select(c => (string)c.GetType().GetProperty(fieldName).GetValue(c)).Distinct().ToList();
            /*string sqlStringGetTable = sqlService.getDistinctValueFromTable(fieldName, ETableName.CAR);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return dataTable.AsEnumerable()
                .Select(row => row[fieldName].ToString())
                .ToList();*/
        }
        public List<Car> getListCarByCondition(string City, string Brand, int Seats, DateTime Start, DateTime End)
        {
            try
            {
                var listAvailable = db.Cars.GroupJoin(db.Orders.Where(o => o.StartDate >= Start && o.EndDate <= End && o.Status != EOrderStatus.CANCELBYADMIN.ToString() && o.Status != EOrderStatus.CANCELBYUSER.ToString()), car => car.ID, order => order.CarId, (car, orders) => new { Car = car, Orders = orders }).Where(x => !x.Orders.Any() && x.Car.Status != ECarStatus.UNAVAILABLE.ToString()).Select(x => x.Car);
                Func<Car, bool> cityCondition = null;
                if (City != null){ cityCondition = x => x.City == City; }
                Func<Car, bool> brandCondition = null;
                if (Brand != null) { brandCondition = x => x.Brand == Brand; }
                Func<Car, bool> seatsCondition = null;
                if (Seats != 0) { seatsCondition = x => x.Seats == Seats; }

                var carPropCondition = cityCondition != null || brandCondition != null || seatsCondition != null
                        ? listAvailable.Where(x => (cityCondition == null || (cityCondition != null && (cityCondition(x) ? true : false))) &&
                                                  (brandCondition == null || (brandCondition != null && (brandCondition(x) ? true : false))) &&
                                                  (seatsCondition == null || (seatsCondition != null && (seatsCondition(x) ? true : false))))
                        : listAvailable;
                return carPropCondition.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public bool checkIsAvailable(DateTime start, DateTime end, int carId)
        {
            var listAvailable = db.Cars.GroupJoin(db.Orders.Where(o => o.StartDate >= start && o.EndDate <= end && o.Status != EOrderStatus.CANCELBYADMIN.ToString() && o.Status != EOrderStatus.CANCELBYUSER.ToString()), car => car.ID, order => order.CarId, (car, orders) => new { Car = car, Orders = orders }).Where(x => !x.Orders.Any() && x.Car.Status != ECarStatus.UNAVAILABLE.ToString()).Select(x => x.Car);
            var isExist = listAvailable.Count(c => c.ID == carId);
            return (int)isExist == 1;
        }

    }
}

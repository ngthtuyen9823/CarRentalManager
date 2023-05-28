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
using System.Windows.Controls;
using System.Runtime.InteropServices.ComTypes;

namespace CarRentalManager.dao
{
    public class CarDAO
    {
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

        public List<Car> getListCarByDescOrAsc(bool isDescrease)
        {
            return isDescrease ? (from car in db.Cars
                                  orderby car.Price descending
                                  select car).ToList() : (from car in db.Cars
                                                          orderby car.Price
                                                          select car).ToList();
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
        public List<string> gitDistintByBrand()
        {
            return db.Cars.Select(car => car.Brand).Distinct().ToList();

        }
        public List<string> gitDistintBySeats()
        {
            return db.Cars.Select(car => car.Seats.ToString()).Distinct().ToList();

        }
        public List<string> gitDistintByCity()
        {
            return db.Cars.Select(car => car.City).Distinct().ToList();

        }
        public List<Car> getListCarByCondition(string City, string Brand, int Seats, DateTime Start, DateTime End)
        {
            try
            {
                var listAvailable = getListCarsAvailable(Start, End);

                if (City != "" && City != null)
                    listAvailable = from car in listAvailable
                                    where car.City == City
                                    select car;
                if (Brand != "" && Brand != null)
                {
                    listAvailable = from car in listAvailable
                                    where car.Brand == Brand.Trim()
                                    select car;
                }
                if (Seats != 0 && Seats.ToString() != null)
                    listAvailable = from car in listAvailable
                                    where car.Seats == Seats
                                    select car;
                return listAvailable.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public bool checkIsAvailable(DateTime start, DateTime end, int carId)
        {
            var listAvailable = getListCarsAvailable(start, end);
            var isExist = listAvailable.Count(c => c.ID == carId);
            return (int)isExist == 1;
        }

        public IQueryable<Car> getListCarsAvailable(DateTime start, DateTime end)
        {
            return db.Cars.GroupJoin(db.Orders
                .Where(o => (o.StartDate <= start && o.EndDate >= start || o.StartDate <= end && o.EndDate >= end)
                    && o.Status != EOrderStatus.CANCELBYADMIN.ToString()
                    && o.Status != EOrderStatus.CANCELBYUSER.ToString()), car => car.ID, order => order.CarId,
                    (car, orders) => new { Car = car, Orders = orders })
                    .Where(x => !x.Orders.Any() && x.Car.Status != ECarStatus.UNAVAILABLE.ToString())
                    .Select(x => x.Car);
        }
    }
}

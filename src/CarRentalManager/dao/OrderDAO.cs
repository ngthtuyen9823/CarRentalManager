using CarRentalManager.enums;
using CarRentalManager.models;
using CarRentalManager.services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CarRentalManager.dao
{
    public class OrderDAO
    {
        readonly Context db = new Context();
        public OrderDAO() { }
        public List<Order> getListOrder()
        {
            return db.Orders.ToList();
        }
        public List<ExtraOrder> getListExtraOrder()
        {
            var extraOrders =
                        from o in db.Orders
                        join cus in db.Customers on o.CustomerId equals cus.ID
                        join c in db.Cars on o.CarId equals c.ID
                        select new { o, CustomerName = cus.Name, CustomerIdCard = cus.IdCard, CarName = c.Name };
            return (List<ExtraOrder>)extraOrders;
        }
        public void createOrder(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }
        public Order getOrderById(string id)
        {
            return db.Orders.Find(id);
        }
        public void updateOrder(Order order)
        {
            order.UpdatedAt = DateTime.Now;
            db.Orders.AddOrUpdate(order);
            db.SaveChanges();
        }
        public void updateStatusOfOrder(Order order)
        {
            order.Status = EOrderStatus.COMPLETE.ToString();
            order.UpdatedAt = DateTime.Now;
            db.Orders.AddOrUpdate(order);
            db.SaveChanges();
        }
        public List<Order> getListOrderCancelByUser()
        {
            return db.Orders.Where(p => p.Status == EOrderStatus.CANCELBYUSER.ToString()).ToList();
        }
        public List<Order> getListOrderByMonth(int month, int year)
        {
            return db.Orders.Where(p => p.Status == EOrderStatus.CANCELBYUSER.ToString())
                            .Where(p => p.UpdatedAt.Value.Month == month)
                            .Where(p => p.UpdatedAt.Value.Year == year).ToList();
        }
        public List<Order> getListOrderByYear(int year)
        {
            return db.Orders.Where(p => p.Status == EOrderStatus.CANCELBYUSER.ToString())
                            .Where(p => p.UpdatedAt.Value.Year == year).ToList();
        }
        public List<Order> getListOrderByPreciouse(int preciouse, int year)
        {
            return db.Orders.Where(p => p.Status == EOrderStatus.CANCELBYUSER.ToString())
                            .Where(p => p.UpdatedAt.Value.Year == year)
                            .Where(p => p.UpdatedAt.Value.Month == (preciouse - 1) * 3 + 1 || p.UpdatedAt.Value.Month == (preciouse - 1) * 3 + 2 || p.UpdatedAt.Value.Month == (preciouse - 1) * 3 + 3).ToList();
        }

        public List<Order> getListOrderByCarId(string carId)
        {
            return (from order in db.Orders
                    where order.CarId.ToString() == carId
                    select order).ToList();
        }
    }
}

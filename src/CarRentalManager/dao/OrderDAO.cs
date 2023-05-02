using CarRentalManager.enums;
using CarRentalManager.services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Windows;
using System.Windows.Controls;

namespace CarRentalManager.dao
{
    public class OrderDAO
    {
        public OrderDAO() { }

        public List<Order> getListOrder()
        {
            using (var db = new CRMContext())
            {
                return db.Orders.ToList();
            }
        }
        public List<ExtraOrder> getListExtraOrder()
        {
            string sqlStringGetTable = sqlService.getListExtraOrder();
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return commondDataService.dataTableToList<ExtraOrder>(dataTable);
        }
        public void createOrder(Order order)
        {
            using (var db = new CRMContext())
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }
        }

        public Order getOrderById(string id)
        {
            using (var db = new CRMContext())
            {
                return db.Orders.Find(id);
            }
        }

        public void removeOrder(int id)
        {
            try
            {
                using (var db = new CRMContext())
                {
                    var contract = db.Orders.Find(id);
                    db.Orders.Remove(contract);
                    db.SaveChanges();
                }
            }
            catch
            {
                throw new System.Exception();
            }
        }
        public void updateOrder(Order order)
        {
            using (var db = new CRMContext())
            {
                order.updatedAt = DateTime.Now;
                db.Orders.AddOrUpdate(order);
                db.SaveChanges();
            }
        }
        public void updateStatusOfOrder(Order order)
        {
            using (var db = new CRMContext())
            {
                order.status = EOrderStatus.COMPLETE.ToString();
                order.updatedAt = DateTime.Now;
                db.Orders.AddOrUpdate(order);
                db.SaveChanges();
            }
        }

        public List<Order> getListOrderByCondition(string condition) {
            using (var db = new CRMContext())
            {
                return db.Orders.Where(condition).ToList();
            }
        }
    }
}

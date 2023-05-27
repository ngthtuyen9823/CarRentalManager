using CarRentalManager.enums;
using CarRentalManager.services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CarRentalManager.models;
using System.Diagnostics;
using System.Security.Policy;
using System.Windows.Media;
using System.Xml.Linq;
using System.Data.SqlTypes;
using System.Data.Entity;
using System.Collections;
using System.Runtime.Remoting.Contexts;
using System.Linq.Dynamic.Core;

namespace CarRentalManager.dao
{
    public class CommonDAO
    {
        private SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        readonly SqlQueryService sqlService = new SqlQueryService();
        readonly VariableService variableService = new VariableService();
        readonly DbConnectionDAO dbConnectionDAO = new DbConnectionDAO();
        readonly Context db = new Context();

        public CommonDAO() { }
        public int getSupplierId(string contractId)
        {
            return (from contract in db.Contracts
                            join order in db.Orders on contract.OrderId equals order.ID
                            join car in db.Cars on order.CarId equals car.ID
                            where contract.ID.ToString() == contractId
                            select car.SupplierId
                        ).FirstOrDefault() ?? 0;
        }
        public List<int> getListOrderId(string supplierId)
        {
            var listOrderId = from carId in
                     (from supplier in db.Suppliers
                      join car in db.Cars on supplier.ID equals car.SupplierId
                      where supplier.ID.ToString() == supplierId
                      select new { car.ID })
                       join order in db.Orders on carId.ID equals order.CarId
                       select order.ID;

            return listOrderId.ToList();
        }
        public int getLastId(ETableName eTableName)
        {
            switch(eTableName)
            {
                case ETableName.CAR:
                    return (from car in db.Cars
                            orderby car.ID descending
                            select car.ID).ToList().FirstOrDefault();

                case ETableName.ORDER:
                    return (from order in db.Orders
                            orderby order.ID descending
                            select order.ID).ToList().FirstOrDefault();

                case ETableName.CONTRACT:
                    return (from contracts in db.Contracts
                            orderby contracts.ID descending
                            select contracts.ID).ToList().FirstOrDefault();
               
                case ETableName.SUPPLIER:
                    return (from suppliers in db.Suppliers
                            orderby suppliers.ID descending
                            select suppliers.ID).ToList().FirstOrDefault();

                default: return 0;
            }
        }

        public Dictionary<string, int> countOnrentTimes()
        {
            return (from order in db.Orders
                     join contract in db.Contracts on order.ID equals contract.OrderId
                     join car in db.Cars on order.CarId equals car.ID
                     group order by car.Name into groupedOrders
                     select new
                     {
                         name = groupedOrders.Key,
                         onrentTimes = (from order in db.Orders
                                        join contract in db.Contracts on order.ID equals contract.OrderId
                                        join car in db.Cars on order.CarId equals car.ID
                                        where car.Name == groupedOrders.Key
                                        select contract.ID).Count()
                     }).ToDictionary(item => item.name, item => item.onrentTimes);
        }

        public Dictionary<string, int> countBrokenTimes()
        {
            return (from contract in db.Contracts
                             join order in db.Orders on contract.OrderId equals order.ID
                             join car in db.Cars on order.CarId equals car.ID
                             where contract.ReturnCarStatus == EReturnCarStatus.BROKEN.ToString()
                             group contract by car.Name into groupedContracts
                             select new
                             {
                                 name = groupedContracts.Key,
                                 brokenTimes = (from contract in db.Contracts
                                                join order in db.Orders on contract.OrderId equals order.ID
                                                join car in db.Cars on order.CarId equals car.ID
                                                where contract.ReturnCarStatus == EReturnCarStatus.BROKEN.ToString()
                                                && car.Name == groupedContracts.Key
                                                select contract.ID).Count()
                             }
                        ).ToDictionary(item => item.name, item => item.brokenTimes);
        }

        public Dictionary<string, string> getListFeedbackOfCustomer()
        {
            return (from contract in db.Contracts
                                join order in db.Orders on contract.OrderId equals order.ID
                                join customer in db.Customers on order.CustomerId equals customer.ID
                                where contract.ReturnCarStatus == EReturnCarStatus.INTACT.ToString() &&
                                      contract.Feedback != null && contract.Feedback != ""
                                group contract by customer.Name into groupedContracts
                                select new
                                {
                                    name = groupedContracts.Key,
                                    feedback = groupedContracts.Min(c => c.Feedback)
                                }
                            ).ToDictionary(item => item.name, item => item.feedback);
        }

        public Dictionary<string, string> getDictionary(DataTable dataTable)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (DataRow row in dataTable.Rows)
            {
                result.Add(row[0].ToString(), row[1].ToString());
            }
            return result;
        }
    }
}

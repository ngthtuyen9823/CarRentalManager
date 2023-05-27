using CarRentalManager.dao;
using CarRentalManager.enums;
using CarRentalManager.models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace CarRentalManager.services
{
    public class StatisticsService
    {
        readonly ContractDAO contractDAO = new ContractDAO();
        readonly CarDAO carDAO = new CarDAO();
        readonly OrderDAO orderDAO = new OrderDAO();
        readonly CommonDAO commonDAO = new CommonDAO(); 
        public StatisticsService() { } 

        public int getTotalRevenue()
        {
            List<Contract> contractList = contractDAO.getListContract();
            List<Order> orderList = orderDAO.getListOrderCancelByUser();
            return getTotalRevenueGiven(contractList, orderList);
        }
        public int getTotalOrder()
        {
            return orderDAO.getListOrder().Count();
        }
        public int getTotalContract()
        {
            return contractDAO.getListContract().Count();
        }
        public int getTotalCar()
        {
            return carDAO.getListCar().Count();
        }
        public int getTotalRevenueGiven(List<Contract> contractList, List<Order> orderList)
        {
            int total = 0;

            contractList?.ForEach(contract =>
            {
                total += contract?.ReceivedFee ?? 0;
            });

            orderList?.ForEach(order =>
            {
                total += order?.DepositAmount ?? 0;
            });
            return total;
        }
        public int getTotalRevenueByMonth(int month)
        {
            int currentYear = DateTime.Now.Year;
            List<Contract> contractList = contractDAO.getListContractByMonth(month, currentYear);
            List<Order> orderList = orderDAO.getListOrderByMonth(month, currentYear);

            return getTotalRevenueGiven(contractList, orderList);
        }
        public int getTotalRevenueByYear(int year)
        {
            List<Contract> contractList = contractDAO.getListContractByYear(year);
            List<Order> orderList = orderDAO.getListOrderByYear(year);
            return getTotalRevenueGiven(contractList, orderList);
        }
        public int getTotalRevenueByPrecious(int preciouse)
        {
            int currentYear = DateTime.Now.Year;
            List<Contract> contractList = contractDAO.getListContractByPreciouse(preciouse, currentYear);
            List<Order> orderList = orderDAO.getListOrderByPreciouse(preciouse, currentYear);
            return getTotalRevenueGiven(contractList, orderList);
        }
        public Dictionary<string, int> getDictTotalRevenueByMonth()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 1; i <= 12; i++)
            {
                dict.Add($"{i}", getTotalRevenueByMonth(i));
            }
            return dict;
        }
        public Dictionary<string, int> getDictTotalRevenueByYear()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 2019; i <= 2023; i++)
            {
                dict.Add($"{i}", getTotalRevenueByYear(i));
            }
            return dict;
        }
        public Dictionary<string, int> getDictTotalRevenueByPrecious()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 1; i <= 4; i++)
            {
                dict.Add($"{i}", getTotalRevenueByPrecious(i));
            }
            return dict;
        }
        public Dictionary<string, int> getDictOnrentTimes()
        {
            DataTable dataTable = commonDAO.countOnrentTimes();
            Dictionary<string, int> result = getDictionary(dataTable);
            return result;
        }
        public Dictionary<string, int> getDictBrokennTimes()
        {
            DataTable dataTable = commonDAO.countBrokenTimes();
            Dictionary<string, int> result = getDictionary(dataTable);
            return result;
        }
        public Dictionary<string, int> getDictionary(DataTable dataTable)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (DataRow row in dataTable.Rows)
            {
                string name = "";
                int times = 0;
                foreach (DataColumn col in dataTable.Columns)
                {
                    object value = row[col]; 
                    if (value is string)
                    {
                        name = value.ToString().Trim();
                    }
                    else if (value is int)
                    {
                        times = (int)value;
                    }
                }
                result.Add(name, times);
            }
            return result;
        }
    }
}

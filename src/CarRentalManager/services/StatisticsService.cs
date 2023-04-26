﻿using CarRentalManager.dao;
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

namespace CarRentalManager.services
{
    public class StatisticsService
    {
        readonly ContractDAO contractDAO = new ContractDAO();
        readonly OrderDAO orderDAO = new OrderDAO();
        readonly CommonDAO commonDAO = new CommonDAO(); 
        public StatisticsService() { } 


        public int getTotalRevenue()
        {
            List<Contract> contractList = contractDAO.getListContract();
            List<Order> orderList = orderDAO.getListOrderByCondition(string.Format("status = {0}", EOrderStatus.CANCELBYUSER));

            return getTotalRevenueGiven(contractList, orderList);
        }

        public int getTotalRevenueGiven(List<Contract> contractList, List<Order> orderList)
        {
            int total = 0;

            contractList?.ForEach(contract =>
            {
                total += contract?.Paid ?? 0;
            });

            orderList?.ForEach(order =>
            {
                total += order?.DepositAmount ?? 0;
            });

            return total;
        }


        public int getTotalRevenueByMonth(int month)
        {
            int currenYear = DateTime.Now.Year;
            List<Contract> contractList = contractDAO.getListByCondition($"Month(updatedAt) = '{month}' and Year(updatedAt) = {currenYear}");
            List<Order> orderList = orderDAO.getListOrderByCondition($"status = '{EOrderStatus.CANCELBYUSER}' and Month(updatedAt) = '{month}' and Year(updatedAt) = '{currenYear}'");

            return getTotalRevenueGiven(contractList, orderList);
        }

        public int getTotalRevenueByYear(int year)
        {
            List<Contract> contractList = contractDAO.getListByCondition($"Year(updatedAt) = {year}");
            List<Order> orderList = orderDAO.getListOrderByCondition($"status = '{EOrderStatus.CANCELBYUSER}' and Year(updatedAt) = '{year}'");

            return getTotalRevenueGiven(contractList, orderList);
        }

        public int getTotalRevenueByPrecious(int preciouse)
        {
            int currenYear = DateTime.Now.Year;
            string conditionByPrecious = $"Month(updatedAt) = {(preciouse - 1) *3 } + 1" +
                $"or Month(updatedAt) = {(preciouse - 1) * 3 + 2} " +
                $"or Month(updatedAt) = {(preciouse - 1) * 3 + 3}";
            List<Contract> contractList = contractDAO.getListByCondition($"({conditionByPrecious}) and Year(updatedAt) = {currenYear}");
            List<Order> orderList = orderDAO.getListOrderByCondition($"status = '{EOrderStatus.CANCELBYUSER}' and ({conditionByPrecious}) and Year(updatedAt) = '{currenYear}'");

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

        // THEO QUY'
        public Dictionary<string, int> getDictTotalRevenueByPrecious()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 1; i <= 4; i++)
            {
                dict.Add($"{i}", getTotalRevenueByPrecious(i));
            }
            return dict;
        }

        public List<Dictionary<string, object>> getDictOnrentTimes()
        {
            DataTable dataTable = commonDAO.countOnrentTimes();
            List<Dictionary<string, object>> result = getDictionary(dataTable);
            return result;
        }

        public List<Dictionary<string, object>> getDictBrokennTimes()
        {
            DataTable dataTable = commonDAO.countBrokenTimes();
            List<Dictionary<string, object>> result = getDictionary(dataTable);
            return result;
        }

        public List<Dictionary<string, object>> getDictionary(DataTable dataTable)
        {
            List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();
            foreach (DataRow row in dataTable.Rows)
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();
                foreach (DataColumn col in dataTable.Columns)
                {
                    dict.Add(col.ColumnName, row[col]);
                }
                result.Add(dict);
            }
            return result;
        }
    }
}

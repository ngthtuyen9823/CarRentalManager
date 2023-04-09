﻿using CarRentalManager.enums;
using CarRentalManager.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManager.services
{
    public class ReceiptDataService
    {
        private readonly VariableService variableService = new VariableService();
        public ReceiptDataService() { }

        public Receipt createReceiptByRowData(DataRow row)
        {
            int id = variableService.parseStringToInt(row["id"].ToString());
            int contractId = variableService.parseStringToInt(row["contractId"].ToString());
            int price = variableService.parseStringToInt(row["price"].ToString());
            DateTime makingDate = DateTime.Parse(row["makingDate"].ToString());
            DateTime createdAt = DateTime.Parse(row["createdAt"].ToString());
            DateTime updatedAt = DateTime.Parse(row["updatedAt"].ToString());

            return new Receipt(id,
                contractId,
                price,
                createdAt, updatedAt);
        }
    }
}

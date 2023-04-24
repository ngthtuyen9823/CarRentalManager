﻿using System;
using CarRentalManager.enums;

namespace CarRentalManager.models
{
    public class Contract
    {
        int id;
        int orderId;
        int userId;
        EContractStatus status;
        int price;
        int paid;
        int remain;
        DateTime createdAt;
        DateTime updatedAt;

        public Contract(int id, int orderId, int userId, EContractStatus status, int price, int paid, int remain,
            DateTime createdAt,
            DateTime updatedAt)
        {
            this.id = id;
            this.orderId = orderId;
            this.userId = userId;
            this.status = status;
            this.price = price;
            this.paid = paid;
            this.remain = remain;   
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
        }

        public Contract() { }

        public int ID { get { return id; } set { id = value; } }
        public int OrderId { get { return orderId; } set { orderId = value; } }
        public int UserId { get { return userId; } set { userId = value; } }
        public int Price { get { return price; } set { price = value; } }
        public int Paid { get { return paid; } set { paid = value; } }
        public int Remain { get { return remain; } set { remain = value; } }

        public EContractStatus Status { get { return status; } set { status = value; } }
        public DateTime CreatedAt { get { return createdAt; } set { createdAt = value; } }
        public DateTime UpdatedAt { get { return updatedAt; } set { updatedAt = value; } }

    }
}

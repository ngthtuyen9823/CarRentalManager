using System;
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
        DateTime createdAt;
        DateTime updatedAt;

        public Contract(int id, int orderId, int userId, EContractStatus status, int price,
            DateTime createdAt,
            DateTime updatedAt)
        {
            this.id = id;
            this.orderId = orderId;
            this.userId = userId;
            this.status = status;
            this.price = price;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
        }

        public Contract() { }

        public int ID { get { return id; } set { id = value; } }
        public int OrderId { get { return orderId; } set { orderId = value; } }
        public int UserId { get { return userId; } set { userId = value; } }
        public int Price { get { return price; } set { price = value; } }
        public EContractStatus Status { get { return status; } set { status = value; } }
        public DateTime CreatedAt { get { return createdAt; } set { createdAt = value; } }
        public DateTime UpdatedAt { get { return updatedAt; } set { updatedAt = value; } }

    }
}

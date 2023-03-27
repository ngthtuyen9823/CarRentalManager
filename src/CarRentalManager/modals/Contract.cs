using System;
using CarRentalManager.enums;

namespace CarRentalManager.modals
{
    public class Contract
    {
        int id;
        int orderId;
        int userId;
        DateTime makingDay;
        EContractStatus status;
        DateTime createdAt;
        DateTime updatedAt;

        public Contract(int id, int orderId, int userId, DateTime makingDay, EContractStatus status,
            DateTime createdAt,
            DateTime updatedAt)
        {
            this.id = id;
            this.orderId = orderId;
            this.userId = userId;
            this.makingDay = makingDay;
            this.status = status;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
        }

        public int ID { get { return id; } set { id = value; } }
        public int OrderId { get { return orderId; } set { orderId = value; } }
        public int UserId { get { return userId; } set { userId = value; } }
        public EContractStatus Status { get { return status; } set { status = value; } }
        public DateTime MakingDay { get { return makingDay; } set { makingDay = value; } }
        public DateTime CreatedAt { get { return createdAt; } set { createdAt = value; } }
        public DateTime UpdatedAt { get { return updatedAt; } set { updatedAt = value; } }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManager.modals
{
    public class Contract
    {
        int id;
        int orderId;
        int userId;
        DateTime makingDay;
        DateTime createdAt;
        DateTime updatedAt;

        public Contract(int id, int orderId, int userId, DateTime makingDay, DateTime createdAt, DateTime updatedAt)
        {
            this.id = id;
            this.orderId = orderId;
            this.userId = userId;
            this.makingDay = makingDay;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
        }

        public int ID { get { return id; } }
        public int OrderId { get { return orderId; } }
        public int UserId { get { return userId; } }
        public DateTime MakingDay { get { return makingDay; } }
        public DateTime CreatedAt { get { return createdAt; } }
        public DateTime UpdatedAt { get { return updatedAt; } }

    }
}

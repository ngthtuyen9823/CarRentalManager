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

        public Contract(int id, int orderId, int userId, DateTime makingDay)
        {
            this.id = id;
            this.orderId = orderId;
            this.userId = userId;
            this.makingDay = makingDay;
            this.createdAt = DateTime.Now;
            this.updatedAt = DateTime.Now;
        }

        public int ID { get { return id; } set { id = value; } }
        public int OrderId { get { return orderId; } set { orderId = value; } }
        public int UserId { get { return userId; } set { userId = value; } }
        public DateTime MakingDay { get { return makingDay; } set { makingDay = value; } }
        public DateTime CreatedAt { get { return createdAt; } set { createdAt = value; } }
        public DateTime UpdatedAt { get { return updatedAt; } set { updatedAt = value; } }

    }
}

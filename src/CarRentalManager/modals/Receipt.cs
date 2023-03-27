using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManager.modals
{
    public class Receipt
    {
        int id;
        int contractId;
        DateTime makingDay;
        int price;
        DateTime createdAt;
        DateTime updatedAt;

        public Receipt(int id, int contractId, DateTime makingDay, int price,
        DateTime createdAt,
        DateTime updatedAt) {
            this.id = id;
            this.contractId = contractId;
            this.makingDay = makingDay;
            this.price = price;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
        }

        public int ID { get { return id; } }
        public int ContractId { get { return contractId; } }
        public DateTime MakingDay { get { return makingDay; } }
        public int Price { get { return price; } }
        public DateTime CreatedAt { get { return createdAt; } }
        public DateTime UpdatedAt { get { return updatedAt; } }
    }
}

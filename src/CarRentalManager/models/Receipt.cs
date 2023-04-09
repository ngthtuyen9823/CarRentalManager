using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManager.models
{
    public class Receipt
    {
        int id;
        int contractId;
        int price;
        DateTime createdAt;
        DateTime updatedAt;

        public Receipt(int id, int contractId, int price,
        DateTime createdAt,
        DateTime updatedAt) {
            this.id = id;
            this.contractId = contractId;
            this.price = price;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
        }
        public Receipt() { }

        public int ID { get { return id; } set { id = value; } }
        public int ContractId { get { return contractId; } set { contractId = value; } }
        public int Price { get { return price; } set { price = value; } }
        public DateTime CreatedAt { get { return createdAt; } set { createdAt = value; } }
        public DateTime UpdatedAt { get { return updatedAt; } set { updatedAt = value; } }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalManager.enums;

namespace CarRentalManager.modals
{
    public class Customer
    {
		int id;
		string name;
		string phoneNumber;
		string email;
		string idCard;
		string address;
		DateTime createdAt;
		DateTime updateedAt;

		public Customer(int id, 
            string name, 
            string phoneNumber, 
            string email, 
            string idCard, 
            string address, 
            DateTime createdAt, 
            DateTime updateedAt)
        {
            this.id = id;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.idCard = idCard;
            this.address = address;
            this.createdAt = createdAt;
            this.updateedAt = updateedAt;
        }

        public int ID { get { return id; } }
        public string Name { get { return name; } }
        public string PhoneNumber { get { return phoneNumber; } }
        public string Email { get { return email; } }
        public string IDCard { get { return idCard; } }
        public string Address { get { return address; } }
        public DateTime CreatedAt { get { return createdAt; } }
        public DateTime UpdatedAt { get { return updateedAt; } }
    }
}

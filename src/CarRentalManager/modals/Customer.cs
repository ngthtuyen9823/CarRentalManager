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
		DateTime updatedAt;

		public Customer(int id, 
            string name, 
            string phoneNumber, 
            string email, 
            string idCard, 
            string address)
        {
            this.id = id;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.idCard = idCard;
            this.address = address;
            this.createdAt = DateTime.Now;
            this.updatedAt = DateTime.Now;
        }

        public int ID { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }

        public string Email { get { return email; } set { email =  value; } }

        public string IDCard { get { return idCard; } set { idCard = value; } }

        public string Address { get { return address; } set { address= value; } }

        public DateTime CreatedAt { get { return createdAt; } set { createdAt = value; } }
        public DateTime UpdatedAt { get { return updatedAt; }set { UpdatedAt = value; } }
    }
}

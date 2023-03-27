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
        string imageIdCardFront;
        string imageIdCardBack;
        DateTime createdAt;
		DateTime updatedAt;

		public Customer(int id, 
            string name, 
            string phoneNumber, 
            string email, 
            string idCard, 
            string address,
            string imageIdCardFront,
            string imageIdCardBack,
            DateTime createdAt,
            DateTime updatedAt)
        {
            this.id = id;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.idCard = idCard;
            this.address = address;
            this.imageIdCardFront = imageIdCardFront;
            this.imageIdCardBack= imageIdCardBack;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
        }

        public int ID { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }

        public string Email { get { return email; } set { email =  value; } }

        public string IDCard { get { return idCard; } set { idCard = value; } }

        public string Address { get { return address; } set { address= value; } }
        public string ImageIdCardFront { get { return imageIdCardFront; } set { imageIdCardFront = value; } }
        public string ImageIdCardBack { get { return imageIdCardBack; } set { imageIdCardBack = value; } }

        public DateTime CreatedAt { get { return createdAt; } set { createdAt = value; } }
        public DateTime UpdatedAt { get { return updatedAt; }set { UpdatedAt = value; } }
    }
}

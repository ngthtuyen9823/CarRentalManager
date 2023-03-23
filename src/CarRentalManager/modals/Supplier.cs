using System;

namespace CarRentalManager.modals
{
    public class Supplier
    {
        int id;
        string email;
        string phoneNumber;
        string name;
        string address;
        DateTime createdAt;
        DateTime updatedAt;

        public Supplier(int id,
            string email,
            string phoneNumber,
            string name,
            string address)
        {

            this.id = id;
            this.name = name;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.createdAt = DateTime.Now;
            this.updatedAt = DateTime.Now;
        }
       
        public int ID { get { return id; } }
        public string Name { get { return name; } }
        public string Email { get { return email; } }
        public string PhoneNumber { get { return phoneNumber; } }
        public string Address { get { return address; } }
        public DateTime CreatedAt { get { return createdAt; } }
        public DateTime UpdatedAt { get { return updatedAt; } }
    }
}

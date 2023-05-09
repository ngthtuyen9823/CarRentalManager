using System;

namespace CarRentalManager.models
{
    public class Supplier
    {
        int id;
        string email;
        string password;
        string phoneNumber;
        string name;
        string address;
        DateTime createdAt;
        DateTime updatedAt;

        public Supplier(int id,
            string email,
            string password,
            string phoneNumber,
            string name,
            string address,
            DateTime createdAt,
            DateTime updatedAt
        )
        {

            this.id = id;
            this.email = email;
            this.password = password;
            this.phoneNumber = phoneNumber;
            this.name = name;
            this.address = address;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
        }

        public Supplier() { }

        public int ID { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }
        public string Address { get { return address; } set { address = value; } }
        public DateTime CreatedAt { get { return createdAt; } set { createdAt = value; } }
        public DateTime UpdatedAt { get { return updatedAt; } set { updatedAt = value; } }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalManager.enums;

namespace CarRentalManager.models
{
    public class User
    {
        int id;
        string name;
        string email;
        string phoneNumber;
        string password;
        EUserRole role;
        DateTime createdAt;
        DateTime updatedAt;

        public User(int id,
            string name,
            string email,
            string phoneNumber,
            string password,
            EUserRole role,
            DateTime createdAt,
            DateTime updatedAt)
        {

            this.id = id;
            this.name = name;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.password = password;
            this.role = role;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
        }
        public User() { }

        public int ID { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }
        public string Password { get { return password; } set { password = value; } }
        public EUserRole Role { get { return role; } set { role = value; } }
        public DateTime CreatedAt { get { return createdAt; } set { createdAt = value; } }
        public DateTime UpdatedAt { get { return updatedAt; } set { updatedAt = value; } }
    }
}

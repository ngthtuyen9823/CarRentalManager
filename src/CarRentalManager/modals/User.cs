using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalManager.enums;

namespace CarRentalManager.modals
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
            EUserRole role)
        {

            this.id = id;
            this.name = name;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.password = password;
            this.role = role;
            this.createdAt = new DateTime();
            this.updatedAt = new DateTime();
        }
       
        public int ID { get { return id; } }
        public string Name { get { return name; } }
        public string Email { get { return email; } }
        public string PhoneNumber { get { return phoneNumber; } }
        public string Password { get { return password; } }
        public EUserRole Role { get { return role; } }
        public DateTime CreatedAt { get { return createdAt; } }
        public DateTime UpdatedAt { get { return updatedAt; } }
    }
}

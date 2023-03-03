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
        string id;
        string name;
        string email;
        string phoneNumber;
        string addresss;
        string password;
        EUserRole role;
        DateTime createdAt;
        DateTime updatedAt;

        public User(string id,
            string name,
            string email,
            string phoneNumber,
            string addresss,
            string password,
            EUserRole role)
        {

            this.id = id;
            this.name = name;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.addresss = addresss;
            this.password = password;
            this.role = role;
            this.createdAt = new DateTime();
            this.updatedAt = new DateTime();
        }
       
        public string ID { get { return id; } }
        public string Name { get { return name; } }
        public string Email { get { return email; } }
        public string PhoneNumber { get { return phoneNumber; } }
        public string Addresss { get { return addresss; } }
        public string Password { get { return password; } }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManager.modals
{
    public class Car
    {
        string id;
        string name;
        string branch;
        string model;
        int year;
        string color;
        string price;
        ECarStatus status;
        ECarType type
        DateTime createdAt;
        DateTime updatedAt;
        public Car(string id;
        string name,
            string branch,
            string model,
            int year,
            string color,
            string price,
            ECarStatus status,
            ECarType type,
            DateTime createdAt,
            DateTime updatedAt) {
                this.id = id;
                this.name = name;
                this.branch = branch;
                this.model = model;
                this.year = year;
                this.color = color;
                this.role = role;
                this.price = price;
                this.status = status;
                this.type = type;
                this.createdAt = new DateTime();
                this.updatedAt = new DateTime();

    }
}

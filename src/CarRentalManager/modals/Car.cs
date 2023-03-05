using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalManager.enums;

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
        ECarType type;
        DateTime createdAt;
        DateTime updatedAt;
        public Car(string id,
        string name,
            string branch,
            string model,
            int year,
            string color,
            string price,
            ECarStatus status,
            ECarType type,
            DateTime createdAt,
            DateTime updatedAt)
        {
            this.id = id;
            this.name = name;
            this.branch = branch;
            this.model = model;
            this.year = year;
            this.color = color;
            this.price = price;
            this.status = status;
            this.type = type;
            this.createdAt = new DateTime();
            this.updatedAt = new DateTime();
        }

        public string ID { get { return id; } }
        public string Name { get { return name; } }
        public string Branch { get { return branch; } }
        public string Model { get { return model; } }
        public int Year { get { return year; } }
        public string Color { get { return color; } }
        public string Price { get { return price; } }
        public ECarStatus Status { get { return status; } }
        public ECarType Type { get { return type; } }
        public DateTime CreatedAt { get { return createdAt; } }
        public DateTime UpdatedAt { get { return updatedAt; } }

    }
}

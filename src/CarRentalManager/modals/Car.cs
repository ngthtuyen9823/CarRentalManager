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
        int id;
        string name;
        string branch;
        string model;
        int publishYear;
        string color;
        string price;
        ECarStatus status;
        ECarType type;
        EDrivingType drivingType;
        string licensePlate;
        string imagePath;
        string tutorialPath;
        DateTime createdAt;
        DateTime updatedAt;
        public Car(int id,
        string name,
            string branch,
            string model,
            int publishYear,
            string color,
            string price,
            ECarStatus status,
            ECarType type,
            EDrivingType drivingType,
            string licensePlate,
            string imagePath,
            string tutorialPath,
            DateTime createdAt,
            DateTime updatedAt)
        {
            this.id = id;
            this.name = name;
            this.branch = branch;
            this.model = model;
            this.publishYear = publishYear;
            this.color = color;
            this.price = price;
            this.status = status;
            this.type = type;
            this.drivingType = drivingType;
            this.licensePlate = licensePlate;
            this.imagePath = imagePath;
            this.tutorialPath= tutorialPath;
            this.createdAt = new DateTime();
            this.updatedAt = new DateTime();
        }

        public int ID { get { return id; } }
        public string Name { get { return name; } }
        public string Branch { get { return branch; } }
        public string Model { get { return model; } }
        public int PublishYear { get { return publishYear; } }
        public string Color { get { return color; } }
        public string Price { get { return price; } }
        public ECarStatus Status { get { return status; } }
        public ECarType Type { get { return type; } }
        public EDrivingType DrivingType { get { return drivingType; } }
        public string LicensePlate { get { return licensePlate; } }
        public string ImagePath { get { return imagePath; } }
        public string TutorialPath { get { return tutorialPath; } }
        public DateTime CreatedAt { get { return createdAt; } }
        public DateTime UpdatedAt { get { return updatedAt; } }
    }
}

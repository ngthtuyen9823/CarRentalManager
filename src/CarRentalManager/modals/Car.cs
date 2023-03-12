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
        int publishYear;
        string color;
        int price;
        ECarStatus status;
        ECarType type;
        EDrivingType drivingType;
        string licensePlate;
        string imagePath;
        int seats;
        string tutorialPath;
        DateTime createdAt;
        DateTime updatedAt;
        public Car(int id,
        string name,
            string branch,
            int publishYear,
            string color,
            int price,
            ECarStatus status,
            ECarType type,
            EDrivingType drivingType,
            int seats,
            string licensePlate,
            string imagePath,
            string tutorialPath
            )
        {
            this.id = id;
            this.name = name;
            this.branch = branch;
            this.publishYear = publishYear;
            this.color = color;
            this.price = price;
            this.status = status;
            this.type = type;
            this.drivingType = drivingType;
            this.licensePlate = licensePlate;
            this.imagePath = imagePath;
            this.seats = seats;
            this.tutorialPath= tutorialPath;
            this.createdAt = new DateTime();
            this.updatedAt = new DateTime();
        }

        public int ID { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Branch { get { return branch; } set { branch = value; } }
        public int PublishYear { get { return publishYear; } set { publishYear = value; } }
        public string Color { get { return color; } set { color = value; } }
        public int Price { get { return price; } set { price = value; } }
        public ECarStatus Status { get { return status; } set { status = value; } }
        public ECarType Type { get { return type; } set { type = value; } }
        public EDrivingType DrivingType { get { return drivingType; } set { drivingType = value; } }
        public string LicensePlate { get { return licensePlate; } set { licensePlate = value; } }
        public string ImagePath { get { return imagePath; } set { imagePath = value; } }
        public int Seats { get { return seats; } set { seats = value; } }
        public string TutorialPath { get { return tutorialPath; } set { tutorialPath = value; } }
        public DateTime CreatedAt { get { return createdAt; } set { createdAt = value; } }
        public DateTime UpdatedAt { get { return updatedAt; } set { updatedAt = value; } }
    }
}

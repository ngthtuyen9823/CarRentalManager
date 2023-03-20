using CarRentalManager.modals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using CarRentalManager.dao;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using System.Windows.Data;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Collections;

namespace CarRentalManager.ViewModel
{
    public class ListCarViewModel : BaseViewModel, IDataErrorInfo
    {
        public string Error { get { return null; } }
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

        public ObservableCollection<Car> List {get; set;}
        public ICommand AddCommand { get; set; }
        readonly CarDAO carDao = new CarDAO();


        public ListCarViewModel()
        {
            List = getListObservableCar();
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (ErrorCollection.Count > 0)
                    return false;
                else
                    return true;
            }, (p) =>
            {
                carDao.addCarToList(ID, Name, Brand, Color, PublishYear, Type, Status, DrivingType, Seats, LicensePlate, Price, ImagePath, CreatedAt, UpdatedAt);
                List = getListObservableCar();
                OnPropertyChanged(nameof(List));
            });
        }
        private string color;

        public string Color
        {
            get { return color; }
            set
            {
                if (value != color)
                {
                    color = value;
                    OnPropertyChanged("Color");
                }
            }
        }
        private string publishYear;

        public string PublishYear
        {
            get { return  publishYear; }
            set
            {
                if (value != publishYear)
                {
                    publishYear = value;
                    OnPropertyChanged("PublishYear");
                }
            }
        }
        private string drivingType;
        public string DrivingType
        {
            get { return drivingType; }
            set
            {
                if (value != drivingType)
                {
                    drivingType = value;
                    OnPropertyChanged("DrivingType");
                }
            }
        }
        private int seats;

        public int Seats
        {
            get { return seats; }
            set
            {
                if (value != seats)
                {
                    seats = value;
                    OnPropertyChanged("Seats");
                }
            }
        }
        private string imagePath;

        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                if (value != imagePath)
                {
                    imagePath = value;
                    OnPropertyChanged("ImagePath");
                }
            }
        }
        private DateTime createdAt;

        public DateTime CreatedAt
        {
            get { return createdAt; }
            set
            {
                if (value != createdAt)
                {
                    createdAt = value;
                    OnPropertyChanged("CreatedAt");

                }
            }
        }
        private DateTime updatedAt;

        public DateTime UpdatedAt
        {
            get { return updatedAt; }
            set
            {
                if (value != updatedAt)
                {
                    updatedAt = value;
                    OnPropertyChanged("UpdatedAt");

                }
            }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private int id;

        public int ID
        {
            get { return id; }
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged("ID");
                }
            }
        }
        private string brand;

        public string Brand
        {
            get { return brand; }
            set
            {
                if (value != brand)
                {
                    brand = value;
                    OnPropertyChanged("Brand");
                }
            }
        }
        private string type;

        public string Type
        {
            get { return type; }
            set
            {
                if (value != type)
                {
                    type = value;
                    OnPropertyChanged("Type");
                }
            }
        }
        private string status;

        public string Status
        {
            get { return status; }
            set
            {
                if (value != status)
                {
                    status = value;
                    OnPropertyChanged("Status");
                }
            }
        }
        private string licensePlate;

        public string LicensePlate
        {
            get { return licensePlate; }
            set
            {
                if (value != licensePlate)
                {
                    licensePlate = value;
                    OnPropertyChanged("LicensePlate");
                }
            }
        }
        private int price;

        public int Price
        {
            get { return price; }
            set
            {
                if (value != price)
                {
                    price = value;
                    OnPropertyChanged("Price");
                }
            }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;
                switch (name)
                {
                    case "Name":
                        if (string.IsNullOrEmpty(Name))
                            result = "Name cannot be empty";
                        break;
                    case "Brand":
                        if (string.IsNullOrEmpty(Brand))
                            result = "Brand cannot be empty";
                        break;
                    case "Color":
                        if (string.IsNullOrEmpty(Color))
                            result = "Color cannot be empty";
                        break;
                    case "PublishYear":
                        if (string.IsNullOrEmpty(PublishYear))
                            result = "Publish year cannot be empty";
                        break;
                    case "Type":
                        if (string.IsNullOrEmpty(Type))
                            result = "Type cannot be empty";
                        break;
                    case "Status":
                        if (string.IsNullOrEmpty(Status))
                            result = "Status cannot be empty";
                        break;
                    case "DrivingType":
                        if (string.IsNullOrEmpty(Type))
                            result = "Driving type cannot be empty";
                        break;
                    case "Seats":
                        if (seats <= 0)
                            result = "Seats invalid";
                        break;
                    case "LicensePlate":
                        if (string.IsNullOrEmpty(LicensePlate))
                            result = "License plate can not be empty";
                        break;
                    case "Price":
                        if (price <= 0)
                            result = "Price invalid";
                        break;
                    case "ImagePath":
                        if (string.IsNullOrEmpty(ImagePath))
                            result = "Please choose a image";
                        break;
                }
                if (ErrorCollection.ContainsKey(name))
                {
                    ErrorCollection[name] = result;
                    ErrorCollection.Remove(name);
                }
                else if (result != null)
                    ErrorCollection.Add(name, result);

                OnPropertyChanged("ErrorCollection");
                return result;
            }
        }    

        public ObservableCollection<Car> getListObservableCar()
        {
            List<Car> cars = carDao.getListCar();
            ObservableCollection<Car> carList = new ObservableCollection<Car>(cars);
            return carList;
        }
    }
}
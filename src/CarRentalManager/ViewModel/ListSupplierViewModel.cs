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
using CarRentalManager.enums;
using System.Diagnostics;
using System.Security.Policy;
using System.Windows.Media;

namespace CarRentalManager.ViewModel
{
    public class ListSupplierViewModel : BaseViewModel, IDataErrorInfo
    {
        public string Error { get { return null; } }
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        private ObservableCollection<Supplier> list;
        public ObservableCollection<Supplier> List { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand SupplierCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        readonly SupplierDAO supplierDAO = new SupplierDAO();
        readonly CarDAO carDAO = new CarDAO();
        readonly CommonDAO commonDAO = new CommonDAO();
        public ListSupplierViewModel()
        {
            List = getListObservableSupplier();
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (ErrorCollection.Count > 0)
                    return false;
                else
                    return true;
            }, (p) =>
            {
                supplierDAO.addSupplierToList(ID, Name, PhoneNumber, Email, Address);
                List = getListObservableSupplier();
                OnPropertyChanged(nameof(List));
                reSetForm();
            });

            SupplierCommand = new RelayCommand<object>((p) =>
            {
                if (ErrorCollection.Count > 0)
                    return false;
                else
                    return true;
            }, (p) =>
            {
                int lastSupplierId = commonDAO.getLastId(ETableName.SUPPLIER);
                int lastCarId = commonDAO.getLastId(ETableName.CAR);


                supplierDAO.createNewSupplier(lastSupplierId+1, Name, PhoneNumber, Email, Address);

                carDAO.addCarToList(lastCarId + 1,
                    NameCar,
                    BrandCar,
                    ColorCar,
                    PublishYear != null ? PublishYear : "",
                    Type != null ? Type : "",
                    Status != null ? Status : "",
                    DrivingType != null ? DrivingType : "",
                    Seats,
                    LicensePlate,
                    PriceCar,
                    ImageCar,
                    lastSupplierId + 1,
                    CreatedAt,
                    UpdatedAt
                    );

                List = getListObservableSupplier();
                OnPropertyChanged(nameof(List));
                reSetForm();
            });
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
        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (value != phoneNumber)
                {
                    phoneNumber = value;
                    OnPropertyChanged("PhoneNumber");
                }
            }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                if (value != Email)
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set
            {
                if (value != Address)
                {
                    address = value;
                    OnPropertyChanged("Address");
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
        private string nameCar;

        public string NameCar
        {
            get { return nameCar; }
            set
            {
                if (value != NameCar)
                {
                    nameCar = value;
                    OnPropertyChanged("NameCar");
                }
            }
        }

        private string brandCar;

        public string BrandCar
        {
            get { return brandCar; }
            set
            {
                if (value != BrandCar)
                {
                    brandCar = value;
                    OnPropertyChanged("BrandCar");
                }
            }
        }

        private string colorCar;

        public string ColorCar
        {
            get { return colorCar; }
            set
            {
                if (value != ColorCar)
                {
                    colorCar = value;
                    OnPropertyChanged("ColorCar");
                }
            }
        }

        private int priceCar;

        public int PriceCar
        {
            get { return priceCar; }
            set
            {
                if (value != PriceCar)
                {
                    priceCar = value;
                    OnPropertyChanged("PriceCar");
                }
            }
        }

        private string imageCar;

        public string ImageCar
        {
            get { return imageCar; }
            set
            {
                if (value != ImageCar)
                {
                    imageCar = value;
                    OnPropertyChanged("ImageCar");
                }
            }
        }
        private string publishYear;

        public string PublishYear
        {
            get { return publishYear; }
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
        private void reSetForm()
        {
            ID = 0;
            Name = null;
            PhoneNumber = null;
            Email = null;
            Address = null;
        }
        public string this[string columnName]
        {
            get
            {
                string result = null;
                switch (columnName)
                {
                    case "Name":
                        if (string.IsNullOrEmpty(Name))
                            result = "Name cannot be empty";
                        break;
                    case "PhoneNumber":
                        if (string.IsNullOrEmpty(PhoneNumber))
                            result = "Phone number cannot be empty";
                        break;
                    case "Email":
                        if (string.IsNullOrEmpty(Email))
                            result = "Email cannot be empty";
                        break;
                    case "ID":
                        if (ID <= 0)
                            result = "ID invalid";
                        break;
                    case "Address":
                        if (string.IsNullOrEmpty(Address))
                            result = "Address can not be empty";
                        break;
                    case "NameCar":
                        if (string.IsNullOrEmpty(NameCar))
                            result = "NameCar can not be empty";
                        break;
                    case "BrandCar":
                        if (string.IsNullOrEmpty(BrandCar))
                            result = "Brand can not be empty";
                        break;
                    case "ColorCar":
                        if (string.IsNullOrEmpty(ColorCar))
                            result = "Color can not be empty";
                        break;
                    case "PriceCar":
                        if (PriceCar < 0)
                            result = "Price invalid";
                        break;
                    case "ImageCar":
                        if (string.IsNullOrEmpty(ImageCar))
                            result = "Image can not be empty";
                        break;
                    case "LicensePlate":
                        if (string.IsNullOrEmpty(LicensePlate))
                            result = "LicensePlate can not be empty";
                        break;
                    case "Seats":
                        if (Seats <=  0)
                            result = "Price invalid";
                        break;
                }
                if (ErrorCollection.ContainsKey(columnName))
                {
                    ErrorCollection[columnName] = result;
                    ErrorCollection.Remove(columnName);
                }
                else if (result != null)
                    ErrorCollection.Add(columnName, result);

                OnPropertyChanged("ErrorCollection");
                return result;
            }
        }
        public ObservableCollection<Supplier> getListObservableSupplier()
        {
            List<Supplier> suppliers = supplierDAO.getListSupplier();
            ObservableCollection<Supplier> supplierList = new ObservableCollection<Supplier>(suppliers);
            return supplierList;
        }

    }
}

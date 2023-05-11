using CarRentalManager.models;
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
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using CarRentalManager.services;
using CarRentalManager.enums;
using MaterialDesignThemes.Wpf;
using System.Runtime.InteropServices.ComTypes;
using System.IO;
using CarRentalManager.state;

namespace CarRentalManager.ViewModel
{
    public class ListCarViewModel : BaseViewModel, IDataErrorInfo
    {
        readonly VariableService variableService = new VariableService();
        readonly ImageService imgService = new ImageService();
        public string Error { get { return null; } }
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        public ObservableCollection<Car> List {get; set;}
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand SetInformationCommand { get; set; }
        
        readonly CarDAO carDAO = new CarDAO();
        readonly CommonDAO commonDAO = new CommonDAO(); 

        //*INFO: Value binding
        private string color; public string Color { get => color; set => SetProperty(ref color, value, nameof(Color)); }
        public int PublishYear { get => publishYear; set => SetProperty(ref publishYear, value, nameof(PublishYear)); }
        private int publishYear;
        private DateTime createdAt; public DateTime CreatedAt { get => createdAt; set => SetProperty(ref createdAt, value, nameof(CreatedAt)); }
        private DateTime updatedAt; public DateTime UpdatedAt { get => updatedAt; set => SetProperty(ref updatedAt, value, nameof(UpdatedAt)); }
        private int supplierId; public int SupplierId { get => supplierId; set => SetProperty(ref supplierId, value, nameof(SupplierId)); }
        private int seats; public int Seats { get => seats; set => SetProperty(ref seats, value, nameof(Seats)); }
        private string drivingType; public string DrivingType { get => drivingType; set => SetProperty(ref drivingType, value, nameof(DrivingType)); }
        private string city; public string City { get => city; set => SetProperty(ref city, value, nameof(City)); }
        private string imagePath; public string ImagePath { get => imagePath; set => SetProperty(ref imagePath, value, nameof(ImagePath)); }
        private string name; public string Name { get => name; set => SetProperty(ref name, value, nameof(Name)); }
        private int id; public int ID { get => id; set => SetProperty(ref id, value, nameof(ID)); }
        private string brand; public string Brand { get => brand; set => SetProperty(ref brand, value, nameof(Brand)); }
        private string type; public string Type { get => type; set => SetProperty(ref type, value, nameof(Type)); }
        private string status; public string Status { get => status; set => SetProperty(ref status, value, nameof(Status)); }
        private string licensePlate; public string LicensePlate { get => licensePlate; set => SetProperty(ref licensePlate, value, nameof(LicensePlate)); }
        private int price; int Price { get => price; set => SetProperty(ref price, value, nameof(Price)); }
        public ListCarViewModel(bool isAdmin)
        {
            List = isAdmin? getListObservableCar() : getSupplierListObservableCar(LoginInInforState.ID.ToString());
            AddCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handleAddCommand(isAdmin, LoginInInforState.ID.ToString()));
            EditCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handleEditCommand(isAdmin, LoginInInforState.ID.ToString()));
            DeleteCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handleDeleteCommand(isAdmin, LoginInInforState.ID.ToString()));
        }
        private void reSetForm()
        {
            ID = 0;
            SupplierId = 0;
            Name = null;
            Brand = null;
            Color = null;
            PublishYear = 0;
            Type = null;
            Status = null;
            DrivingType = null;
            Seats = 0;
            LicensePlate = null;
            Price = 0;
            ImagePath = null;
            Price = 0;
            CreatedAt = DateTime.Today;
            UpdatedAt = DateTime.Today;
        }
        public string this[string columnName]
        {
            get
            {
                string result = null;
                switch (columnName)
                {
                    case nameof(ID):
                        if (ID <= 0)
                            result = "ID invalid";
                        break;
                    case nameof(Seats):
                        if (seats <= 0)
                            result = "Seats invalid";
                        break;
                    case nameof(Price):
                        if (price <= 0)
                            result = "Price invalid";
                        break;
                    default:
                        if (string.IsNullOrEmpty(typeof(ListCarViewModel).GetProperty(columnName).GetValue(this)?.ToString()))
                            result = string.Format("{0} can not be empty", columnName);
                        break;
                }
                if (ErrorCollection.ContainsKey(columnName))
                {
                    ErrorCollection[columnName] = result;
                    ErrorCollection.Remove(columnName);
                }
                else if (result != null)
                    ErrorCollection.Add(columnName, result);

                OnPropertyChanged(nameof(ErrorCollection));
                return result;
            }
        }    
        public ObservableCollection<Car> getListObservableCar()
        {
            LoginInInforState.ID = 0;
            List<Car> cars = carDAO.getListCar();
            ObservableCollection<Car> carList = new ObservableCollection<Car>(cars);
            return carList;
        }
        public ObservableCollection<Car> getSupplierListObservableCar(string supplierId)
        {
            List<Car> cars = carDAO.getSupplierListCar(supplierId);
            ObservableCollection<Car> carList = new ObservableCollection<Car>(cars);
            return carList;
        }

        private bool checkIsError()
        {
            if (ErrorCollection.Count > 0)
                return false;
            else
                return true;
        }
        private void updateListUI(bool isAdmin, string supplierId)
        {
            MessageBox.Show("Success!");
            List = isAdmin? getListObservableCar() : getSupplierListObservableCar(supplierId);
            OnPropertyChanged(nameof(List));
            reSetForm();
        }
        private Car getCar()
        {
            string imagePath = imgService.getProjectImagePath(ImagePath, "cars", ID.ToString());
            int lastCarID = commonDAO.getLastId(ETableName.CAR);
            return new Car(lastCarID + 1, Name,
                    Brand, PublishYear,
                    Color, Price,
                    variableService.parseStringToEnum<ECarStatus>(Status.Substring(38)),
                    variableService.parseStringToEnum<ECarType>(Type.Substring(38)),
                    variableService.parseStringToEnum<EDrivingType>(DrivingType.Substring(38)),
                    Seats, LicensePlate,
                    ImagePath, imagePath,
                    City != null ? variableService.parseStringToEnum<ECityName>(City.Substring(38)) : ECityName.HCM,
                    LoginInInforState.ID,
                    CreatedAt, UpdatedAt);
        }
        private void handleAddCommand(bool isAdmin, string supplierId)
        {
            Car car = getCar();
            carDAO.createCar(car);
            updateListUI(isAdmin, supplierId);
        }
        private void handleEditCommand(bool isAdmin, string supplierId)
        {
            Car car = getCar();
            carDAO.updateCar(car);
            updateListUI(isAdmin, supplierId);
        }
        private void handleDeleteCommand(bool isAdmin, string supplierId)
        {
            carDAO.removeCar(ID);
            updateListUI(isAdmin, supplierId);
        }
    }
}
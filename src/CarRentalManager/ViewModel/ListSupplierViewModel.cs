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
using CarRentalManager.enums;
using System.Diagnostics;
using System.Security.Policy;
using System.Windows.Media;
using CarRentalManager.services;
using MaterialDesignThemes.Wpf;
using System.Runtime.InteropServices.ComTypes;

namespace CarRentalManager.ViewModel
{
    public class ListSupplierViewModel : BaseViewModel, IDataErrorInfo
    {
        readonly VariableService variableService = new VariableService();
        public string Error { get { return null; } }
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        private ObservableCollection<Supplier> list;
        public ObservableCollection<Supplier> List { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand SupplierCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        readonly SupplierDAO supplierDAO = new SupplierDAO();
        readonly CarDAO carDAO = new CarDAO();
        readonly CommonDAO commonDAO = new CommonDAO();

        //*INFO: Value binding
        private string name; public string Name { get => name; set => SetProperty(ref name, value, nameof(Name)); }
        private int id; public int ID { get => id; set => SetProperty(ref id, value, nameof(ID)); }
        private string phoneNumber; public string PhoneNumber { get => phoneNumber; set => SetProperty(ref phoneNumber, value, nameof(PhoneNumber)); }
        private string email; public string Email { get => email; set => SetProperty(ref email, value, nameof(Email)); }
        private string address; public string Address { get => address; set => SetProperty(ref address, value, nameof(Address)); }
        private string nameCar; public string NameCar { get => nameCar; set => SetProperty(ref nameCar, value, nameof(NameCar)); }
        private string brandCar; public string BrandCar { get => brandCar; set => SetProperty(ref brandCar, value, nameof(BrandCar)); }
        private string colorCar; public string ColorCar { get => colorCar; set => SetProperty(ref colorCar, value, nameof(ColorCar)); }
        private int priceCar; public int PriceCar { get => priceCar; set => SetProperty(ref priceCar, value, nameof(PriceCar)); }
        private string imageCar; public string ImageCar { get => imageCar; set => SetProperty(ref imageCar, value, nameof(ImageCar)); }
        private int publishYear; public int PublishYear { get => publishYear; set => SetProperty(ref publishYear, value, nameof(PublishYear)); }
        private string drivingType; public string DrivingType { get => drivingType; set => SetProperty(ref drivingType, value, nameof(DrivingType)); }
        private int seats; public int Seats { get => publishYear; set => SetProperty(ref seats, value, nameof(Seats)); }
        private string type; public string Type { get => type; set => SetProperty(ref type, value, nameof(Type)); }
        private string status; public string Status { get => status; set => SetProperty(ref status, value, nameof(Status)); }
        private string licensePlate; public string LicensePlate { get => licensePlate; set => SetProperty(ref licensePlate, value, nameof(LicensePlate)); }
        private string city; public string City { get => city; set => SetProperty(ref city, value, nameof(City)); }


        public ListSupplierViewModel()
        {
            List = getListObservableSupplier();
            AddCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handleAddCommand());
            EditCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handleEditCommand());
            DeleteCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handleDeleteCommand());
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
                    case nameof(ID):
                        if (ID <= 0)
                            result = "ID invalid";
                        break;
                    case nameof(PriceCar):
                        if (PriceCar < 0)
                            result = "Price invalid";
                        break;
                    case nameof(Seats):
                        if (Seats <=  0)
                            result = "Price invalid";
                        break;
                    default:
                        if (string.IsNullOrEmpty(typeof(ListSupplierViewModel).GetProperty(columnName).GetValue(this)?.ToString()))
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
        public ObservableCollection<Supplier> getListObservableSupplier()
        {
            List<Supplier> suppliers = supplierDAO.getListSupplier();
            ObservableCollection<Supplier> supplierList = new ObservableCollection<Supplier>(suppliers);
            return supplierList;
        }

        private bool checkIsError()
        {
            if (ErrorCollection.Count > 0)
                return false;
            else
                return true;
        }
        private Supplier getSupplier()
        {
            return new Supplier(ID, Name, PhoneNumber, Email, Address, DateTime.Now, DateTime.Now);
        }

        private void updateListUI()
        {
            MessageBox.Show("Success!");
            List = getListObservableSupplier();
            OnPropertyChanged(nameof(List));
            reSetForm();
        }

        private void handleAddCommand()
        {
            Supplier supplier = getSupplier();
            supplierDAO.createSupplier(supplier);
            updateListUI();
        }

        private void handleEditCommand()
        {
            Supplier supplier = getSupplier();
            supplierDAO.updatSupplier(supplier);
            updateListUI();
        }

        private void handleDeleteCommand()
        {
            supplierDAO.removeSupplier(ID);
            updateListUI();
        }
    }
}

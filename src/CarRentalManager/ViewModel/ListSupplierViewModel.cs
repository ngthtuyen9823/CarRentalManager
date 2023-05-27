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
        readonly ImageService imgService = new ImageService();
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
        private string password; public string Password { get => password; set => SetProperty(ref password, value, nameof(Password)); }
        private string address; public string Address { get => address; set => SetProperty(ref address, value, nameof(Address)); }
        private string nameCar; public string NameCar { get => nameCar; set => SetProperty(ref nameCar, value, nameof(NameCar)); }
        private string brandCar; public string BrandCar { get => brandCar; set => SetProperty(ref brandCar, value, nameof(BrandCar)); }
        private string colorCar; public string ColorCar { get => colorCar; set => SetProperty(ref colorCar, value, nameof(ColorCar)); }
        private int priceCar; public int PriceCar { get => priceCar; set => SetProperty(ref priceCar, value, nameof(PriceCar)); }
        private string imageCar; public string ImageCar { get => imageCar; set => SetProperty(ref imageCar, value, nameof(ImageCar)); }
        private int seats; public int Seats { get => seats; set => SetProperty(ref seats, value, nameof(Seats)); }
        private string status; public string Status { get => status; set => SetProperty(ref status, value, nameof(Status)); }
        private string licensePlate; public string LicensePlate { get => licensePlate; set => SetProperty(ref licensePlate, value, nameof(LicensePlate)); }


        public ListSupplierViewModel()
        {
            List = getListObservableSupplier();
            SupplierCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handleSupplierCommand());
            AddCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handleAddCommand());
            EditCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handleEditCommand());
            DeleteCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handleDeleteCommand());
        }

        private void reSetForm()
        {
            ID = 0;
            Name = string.Empty;
            PhoneNumber = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            Address = string.Empty;
            NameCar = string.Empty;
            BrandCar = string.Empty;
            LicensePlate = string.Empty;
            ColorCar = string.Empty;
            Seats = PriceCar = 0;
            ImageCar = string.Empty;

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
                        if (Seats <  0)
                            result = "Seats invalid";
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
        private Supplier getSupplier(bool isNewSupplier)
        {
            int lastSupplier = commonDAO.getLastId(ETableName.SUPPLIER);
            return new Supplier
            {
                ID = isNewSupplier ? lastSupplier + 1 : ID,
                Email = Email,
                Password = Password,
                PhoneNumber = PhoneNumber,
                Name = Name,
                Address = Address,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now

            };
        }
        private void getaddCar()
        {
            int lastSupplierId = commonDAO.getLastId(ETableName.SUPPLIER);
            int lastCarId = commonDAO.getLastId(ETableName.CAR);
            string imagePath = imgService.getProjectImagePath(ImageCar, "cars", (lastCarId + 1).ToString());
            Car car = new Car();
            car.ID = lastCarId + 1;
            car.Brand = BrandCar;
            car.SupplierId = lastSupplierId;
            car.Color = ColorCar;
            car.Name = NameCar;
            car.LicensePlate = LicensePlate;
            car.Seats = Seats;
            car.ImagePath = ImageCar;
            car.TutorialPath = imagePath;
            car.Price = PriceCar;
            car.Status = ECarStatus.UNAVAILABLE.ToString();
            carDAO.createCar(car);
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
            Supplier supplier = getSupplier(true);
            supplierDAO.createSupplier(supplier);
            updateListUI();
        }

        private void handleEditCommand()
        {
            Supplier supplier = getSupplier(false);
            supplierDAO.updatSupplier(supplier);
            updateListUI();
        }

        private void handleDeleteCommand()
        {
            supplierDAO.removeSupplier(ID);
            updateListUI();
        }
        private void handleSupplierCommand()
        {
            int lastSupplierId = commonDAO.getLastId(ETableName.SUPPLIER);
            Supplier supplier = getSupplier(true);
            supplier.ID = lastSupplierId + 1;
            supplierDAO.createSupplier(supplier);
            getaddCar();
            updateListUI();
            MessageBox.Show("Thank you to be our supplier! " +
                "\n\nPlease using your email and password to login to our space to let we know the time your car is ready");
        }
    }
}

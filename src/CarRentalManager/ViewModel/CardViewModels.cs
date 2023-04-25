using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using CarRentalManager.models;
using CarRentalManager.enums;
using System.Windows.Input;
using CarRentalManager.dao;
using System.Windows.Documents;
using CarRentalManager.constants;
using System.Windows.Controls;

namespace CarRentalManager.ViewModel
{
    class CardViewModels: BaseViewModel
    {
        readonly ResourceDictionary dictionary = Application.LoadComponent(new Uri("/CarRentalManager;component/Assets/icons.xaml", 
            UriKind.RelativeOrAbsolute)) as ResourceDictionary;
        //        ResourceDictionary dictionary = new ResourceDictionary();
        
        readonly CarDAO carDao = new CarDAO();
        readonly Constant constant = new Constant();

        public ICommand SortByAscCommand { get; set; }
        public ICommand SortByDscCommand { get; set; }
        public ICommand SortByCarCommand { get; set; }
        public ICommand SortByBikeCommand { get; set; }
        public ICommand SortByMotoBikeCommand { get; set; }
        public ICommand SortLowerThan200 { get; set; }
        public ICommand SortLowerThan500{ get; set; }
        public ICommand SortLowerThan1000{ get; set; }
        public ICommand SortBiggerThan1000{ get; set; }
        public ICommand SearchCommand { get; set; }

        //*INFO: Value binding
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
        private int price; public int Price { get => price; set => SetProperty(ref price, value, nameof(Price)); }
        private ObservableCollection<string> listCarBrand; public ObservableCollection<string> ListCarBrand { get => listCarBrand; set => SetProperty(ref listCarBrand, value, nameof(ListCarBrand)); }
        private ObservableCollection<string> listCity; public ObservableCollection<string> ListCity { get => listCity; set => SetProperty(ref listCity, value, nameof(ListCity)); }
        private ObservableCollection<string> listSeats; public ObservableCollection<string> ListSeats { get => listSeats; set => SetProperty(ref listSeats, value, nameof(ListSeats)); }
        private ObservableCollection<Car> carList; public ObservableCollection<Car> CarList { get => carList; set => SetProperty(ref carList, value, nameof(CarList)); }


        public CardViewModels()
        {
            this.initializeValue();
            SortByAscCommand = new RelayCommand<object>((p) => {
                return true;
            }, (p) => getListCarSortByDescOrAsc(true, "price"));

            SortByDscCommand = new RelayCommand<object>((p) => {
                return true;
            }, (p) => getListCarSortByDescOrAsc(false, "price"));

            SortByCarCommand = new RelayCommand<object>((p) => {
                return true;
            }, (p) => getListByCarType(ECarType.CAR));

            SortByBikeCommand = new RelayCommand<object>((p) => {
                return true;
            }, (p) => getListByCarType(ECarType.BYCYCLE));

            SortByMotoBikeCommand = new RelayCommand<object>((p) => {
                return true;
            }, (p) => getListByCarType(ECarType.MOTOBIKE));

            SortLowerThan200 = new RelayCommand<object>((p) => {
                return true;
            }, (p) => getListSortByRange(constant.MinPriceOfCar, 200));

            SortLowerThan500 = new RelayCommand<object>((p) => {
                return true;
            }, (p) => getListSortByRange(200, 500));

            SortLowerThan1000 = new RelayCommand<object>((p) => {
                return true;
            }, (p) => getListSortByRange(500, 1000));

            SortBiggerThan1000 = new RelayCommand<object>((p) => {
                return true;
            }, (p) => getListSortByRange(1000, constant.MaxPriceCar));
            SearchCommand = new RelayCommand<object>((p) => {
                return true;
            }, (p) => searchCarHandler());
        }

        private void initializeValue()
        {
            CarList = this.getListObservableCar();
            ListCarBrand = this.getListDistinctValue(nameof(brand));
            ListCity = this.getListDistinctValue(nameof(city));
            ListSeats = this.getListDistinctValue(nameof(seats));
        }

        public ObservableCollection<Car> getListObservableCar()
        {
            List<Car> cars = carDao.getListCar();
            ObservableCollection<Car> carList = new ObservableCollection<Car>(cars);
            return carList;
        }

        public ObservableCollection<string> getListDistinctValue(string fieldName)
        {
            List<string> data = carDao.getListCarBrand(fieldName);
            if (data[0] == "") data.RemoveAt(0);
            data.Insert(0, null);
            ObservableCollection<string> carBrandList = new ObservableCollection<string>(data);
            return carBrandList;
        }

        public void getListCarSortByDescOrAsc(bool isDescrease, string fieldName)
        {
            List<Car> cars = carDao.getListCarByDescOrAsc(isDescrease, fieldName);
            CarList = new ObservableCollection<Car>(cars);
            OnPropertyChanged(nameof(CarList));
        }

        public void getListByCarType(ECarType eCarType)
        {
            List<Car> cars = carDao.getListCarByType(eCarType);
            CarList = new ObservableCollection<Car>(cars);
            OnPropertyChanged(nameof(CarList));
        }

        public void getListSortByRange(int fromPrice, int toPrice)
        {
            List<Car> cars = carDao.getListByRange(fromPrice, toPrice);
            CarList = new ObservableCollection<Car>(cars);
            OnPropertyChanged(nameof(CarList));
        }

        public void searchCarHandler()
        {
            List<Car> cars = carDao.getListCarByCondition(City, Brand, Seats);
            CarList = new ObservableCollection<Car>(cars);
            OnPropertyChanged(nameof(CarList));
        }
    }
}

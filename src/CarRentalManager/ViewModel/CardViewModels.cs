using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

using CarRentalManager.enums;
using System.Windows.Input;
using CarRentalManager.dao;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Diagnostics;

namespace CarRentalManager.ViewModel
{
    class CardViewModels: BaseViewModel
    {
        readonly ResourceDictionary dictionary = Application.LoadComponent(new Uri("/CarRentalManager;component/Assets/icons.xaml", 
            UriKind.RelativeOrAbsolute)) as ResourceDictionary;
        //        ResourceDictionary dictionary = new ResourceDictionary();
        
        readonly CarDAO carDao = new CarDAO();

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
        private string city; public string City { get => city; set => SetProperty(ref city, value, nameof(City)); }
        private string name; public string Name { get => name; set => SetProperty(ref name, value, nameof(Name)); }
        private int id; public int ID { get => id; set => SetProperty(ref id, value, nameof(ID)); }
        private string brand; public string Brand { get => brand; set => SetProperty(ref brand, value, nameof(Brand)); }
        private string type; public string Type { get => type; set => SetProperty(ref type, value, nameof(Type)); }
        private string status; public string Status { get => status; set => SetProperty(ref status, value, nameof(Status)); }
        private int price; public int Price { get => price; set => SetProperty(ref price, value, nameof(Price)); }
        private DateTime start; public DateTime Start { get => start; set => SetProperty(ref start, value, nameof(Start)); }
        private DateTime end; public DateTime End { get => end; set => SetProperty(ref end, value, nameof(End)); }
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
            }, (p) => getListSortByRange(((int)ECarPrice.MINPRICECAR), 200));

            SortLowerThan500 = new RelayCommand<object>((p) => {
                return true;
            }, (p) => getListSortByRange(200, 500));

            SortLowerThan1000 = new RelayCommand<object>((p) => {
                return true;
            }, (p) => getListSortByRange(500, 1000));

            SortBiggerThan1000 = new RelayCommand<object>((p) => {
                return true;
            }, (p) => getListSortByRange(1000, ((int)ECarPrice.MAXPRICECAR)));
            SearchCommand = new RelayCommand<object>((p) => {
                return true;
            }, (p) => searchCarHandler());
        }

        private void initializeValue()
        {
            try
            {
                CarList = this.getListObservableCar();
                ListCarBrand = this.getListDistinctValue(nameof(brand));
                ListCity = this.getListDistinctValue(nameof(city));
                ListSeats = this.getListDistinctValue(nameof(seats));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ObservableCollection<Car> getListObservableCar()
        {
            try
            {
                List<Car> cars = carDao.getListCar();
                ObservableCollection<Car> carList = new ObservableCollection<Car>(cars);
                return carList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public ObservableCollection<string> getListDistinctValue(string fieldName)
        {
            try
            {
                List<string> data = carDao.getListCarBrand(fieldName);
                if (data[0] == "") data.RemoveAt(0);
                data.Insert(0, null);
                ObservableCollection<string> carBrandList = new ObservableCollection<string>(data);
                return carBrandList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void getListCarSortByDescOrAsc(bool isDescrease, string fieldName)
        {
            try
            {
                List<Car> cars = carDao.getListCarByDescOrAsc(isDescrease, fieldName);
                CarList = new ObservableCollection<Car>(cars);
                OnPropertyChanged(nameof(CarList));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void getListByCarType(ECarType eCarType)
        {
            try
            {
                List<Car> cars = carDao.getListCarByType(eCarType);
                CarList = new ObservableCollection<Car>(cars);
                OnPropertyChanged(nameof(CarList));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void getListSortByRange(int fromPrice, int toPrice)
        {
            try
            {
                List<Car> cars = carDao.getListByRange(fromPrice, toPrice);
                CarList = new ObservableCollection<Car>(cars);
                OnPropertyChanged(nameof(CarList));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void searchCarHandler()
        {
            try
            {
                if(City == null && Brand == null && Seats == 0 && Start == null && End == null)
                {
                    return;
                }
                List<Car> cars = carDao.getListCarByCondition(City, Brand, Seats, Start, End);
                CarList = new ObservableCollection<Car>(cars);
                OnPropertyChanged(nameof(CarList));
            }
            catch(Exception ex) { 
                MessageBox.Show(ex.Message);
            }
        }
    }
}

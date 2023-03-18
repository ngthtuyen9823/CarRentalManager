using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using CarRentalManager.modals;
using CarRentalManager.enums;
using System.Windows.Input;
using CarRentalManager.dao;
using System.Windows.Documents;

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
        public CardViewModels()
        {
            CarList = this.getListObservableCar();
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
        }

        public ObservableCollection<Car> getListObservableCar()
        {
            List<Car> cars = carDao.getListCar();
            ObservableCollection<Car> carList = new ObservableCollection<Car>(cars);
            return carList;
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

        private ObservableCollection<Car> carList;

        public ObservableCollection<Car> CarList
        {
            get { return carList; }
            set
            {
                if (value != carList)
                {
                    carList = value;
                    OnPropertyChanged("CarList");
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

        private bool isSelfDriving;
        public bool IsSelfDriving
        {
            get { return isSelfDriving; }
            set
            {
                if (value != isSelfDriving)
                {
                    isSelfDriving = value;
                    OnPropertyChanged("IsSelfDriving");
                }
            }
        }

    }
}

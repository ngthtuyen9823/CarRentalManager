using CarRentalManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using CarRentalManager.modals;
using System.Security.Policy;
using System.Xml.Linq;
using CarRentalManager.enums;
using CarRentalManager.services;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Input;
using CarRentalManager.dao;

namespace CarRentalManager.ViewModel
{
    class CardViewModels: BaseViewModel
    {
        readonly ResourceDictionary dictionary = Application.LoadComponent(new Uri("/CarRentalManager;component/Assets/icons.xaml", 
            UriKind.RelativeOrAbsolute)) as ResourceDictionary;
        //        ResourceDictionary dictionary = new ResourceDictionary();
        public ObservableCollection<Car> carList { get; set; }
        readonly CarDAO carDao = new CarDAO();

        public ICommand SortByAscCommand { get; set; }

        public ObservableCollection<Car> CarList
        {
            get { return carList; }
            set {
                if (carList != value)
                {
                    carList = value;
                    OnPropertyChanged(nameof(CarList));
                }
            }
        }

        public CardViewModels()
        {
            carList = this.getListObservableCar();
            SortByAscCommand = new RelayCommand<object>((p) => {
                return true;
            }, (p) => changeCardViewModels(false));

        }
        public void changeCardViewModels(bool isSortedDesc)
        {
            MessageBox.Show(isSortedDesc.ToString());
            MessageBox.Show(carList[0].Name);
            carList = this.getListObservableCarSortByDescOrAsc(isSortedDesc, "price");
            MessageBox.Show(carList[0].Name);
            OnPropertyChanged(nameof(CarList));
        }

        public ObservableCollection<Car> getListObservableCar()
        {
            List<Car> cars = carDao.getListCar();
            ObservableCollection<Car> carList = new ObservableCollection<Car>(cars);
            return carList;
        }

        public ObservableCollection<Car> getListObservableCarSortByDescOrAsc(bool isDescrease, string fieldName)
        {
            List<Car> cars = carDao.getListCarByDescOrAsc(isDescrease, fieldName);
            ObservableCollection<Car> carList = new ObservableCollection<Car>(cars);
            return carList;
        }
    }
}

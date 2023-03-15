using CarRentalManager.modals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CarRentalManager.enums;
using static System.Net.Mime.MediaTypeNames;
using CarRentalManager.services;
using CarRentalManager.dao;

namespace CarRentalManager.ViewModel
{
    public class ListCarViewModel : BaseViewModel
    {
        private ObservableCollection<Car> list;
        public ObservableCollection<Car> List {get; set;}
        readonly CarDAO cardDao = new CarDAO();

        public ListCarViewModel()
        {
            List = getListObservableCar();
        }
        public ObservableCollection<Car> getListObservableCar()
        {
            List<Car> cars = cardDao.getListCar();
            ObservableCollection<Car> carList = new ObservableCollection<Car>(cars);
            return carList;
        }
    }
}
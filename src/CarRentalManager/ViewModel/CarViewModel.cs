using CarRentalManager.dao;
using CarRentalManager.modals;
using CarRentalManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Car = CarRentalManager.Model.Car;

namespace CarRentalManager.ViewModel
{
    public class CarViewModel : BaseViewModel
    {
        private ObservableCollection<Car> list;
        public ObservableCollection<Car> List { get=> list; set { list = value; OnPropertyChanged(); } }

        public CarViewModel()
        {
            List = new ObservableCollection<Car>(DataProvider.Ins.DB.Cars);
        }
    }
}

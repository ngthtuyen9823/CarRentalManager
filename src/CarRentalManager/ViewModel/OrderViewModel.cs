using CarRentalManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManager.ViewModel
{
    internal class OrderViewModel : BaseViewModel   
    {
        private ObservableCollection<Order> list;
        public ObservableCollection<Order> List { get => list; set { list = value; OnPropertyChanged(); } }

        public OrderViewModel()
        {
            List = new ObservableCollection<Order>(DataProvider.Ins.DB.Orders);
        }
    }
}

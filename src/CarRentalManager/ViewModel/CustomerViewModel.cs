using CarRentalManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManager.ViewModel
{
    internal class CustomerViewModel  : BaseViewModel   
    {
        private ObservableCollection<Customer> list;
        public ObservableCollection<Customer> List { get => list; set { list = value; OnPropertyChanged(); } }

        public CustomerViewModel()
        {
            List = new ObservableCollection<Customer>(DataProvider.Ins.DB.Customers);
        }
    }
}

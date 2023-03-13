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

namespace CarRentalManager.ViewModel
{
    class CardViewModels
    {
        readonly ResourceDictionary dictionary = Application.LoadComponent(new Uri("/CarRentalManager;component/Assets/icons.xaml", 
            UriKind.RelativeOrAbsolute)) as ResourceDictionary;
        //        ResourceDictionary dictionary = new ResourceDictionary();
        readonly SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        readonly SqlQueryService sqlService = new SqlQueryService();
        readonly CarDataService carDataService = new CarDataService();
        public ObservableCollection<Car> _course { get; set; }

        public ObservableCollection<Car> Courses
        {
            get { return _course; }
            set { _course = value; }
        }

        public CardViewModels()
        {

            _course = this.getListObservableCar();
        }
        public ObservableCollection<Car> getListObservableCar()
        {
            string sqlStringGetTable = sqlService.getListTableData(ETableName.CAR);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlStringGetTable, conn);
            DataTable dataTableCar = new DataTable();
            adapter.Fill(dataTableCar);

            ObservableCollection<Car> carList = new ObservableCollection<Car>();
            for (int i = 0; i < dataTableCar.Rows.Count; i++)
            {
                var row = dataTableCar.Rows[i];
                Car newCar = carDataService.craeteCarByRowData(row);
                carList.Add(newCar);
            }
            return carList;
        }
    }
}

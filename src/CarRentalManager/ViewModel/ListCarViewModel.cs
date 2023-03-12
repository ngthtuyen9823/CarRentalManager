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

namespace CarRentalManager.ViewModel
{
    public class ListCarViewModel
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        SqlQueryService sqlService = new SqlQueryService();

        private ObservableCollection<Car> list;
        //public ObservableCollection<Car> List { get => list; set { list = value; OnPropertyChanged(); } }
        public ObservableCollection<Car> List {get; set;}

        public ListCarViewModel()
        {
            List = getListObservableCar();
        }
        //public void Load()
        //{
        //    try
        //    {
        //        conn.Open();
        //        string sqlStr = string.Format("SELECT *FROM HocSinh");


        //        SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
        //        DataTable dtSinhVien = new DataTable();
        //        adapter.Fill(dtSinhVien);
        //        gvHsinh.DataSource = dtSinhVien;
        //    }
        //    catch (Exception exc)
        //    {
        //        MessageBox.Show(exc.Message);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        public ObservableCollection<Car> getListObservableCar()
        {
            string sqlStringGetTable = sqlService.getListTableData(ETableName.CAR);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlStringGetTable, conn);
            DataTable dataTableCar = new DataTable();
            adapter.Fill(dataTableCar);

            ObservableCollection<Car> carList = new ObservableCollection<Car>();
            for (int i = 0; i < dataTableCar.Rows.Count; i++)
            {
                int id, publishYear, price, seats;
                var row = dataTableCar.Rows[i];
                ECarStatus status;
                ECarType type;
                EDrivingType drivingType;
                Enum.TryParse<ECarStatus>(row["status"].ToString(), out status);
                Enum.TryParse<ECarType>(row["type"].ToString(), out type);
                Enum.TryParse<EDrivingType>(row["drivingType"].ToString(), out drivingType);
                int.TryParse(row["id"].ToString(), out id);
                int.TryParse(row["publishYear"].ToString(), out publishYear);
                int.TryParse(row["price"].ToString(), out price);
                int.TryParse(row["seats"].ToString(), out seats);

                carList.Add(
                    new Car(id,
                    row["name"].ToString(),
                    row["branch"].ToString(),
                    publishYear,
                    row["color"].ToString(),
                    price,
                    status,
                    type,
                    drivingType,
                    seats,
                    row["licensePlate"].ToString(),
                    row["imagePath"].ToString(),
                    row["tutorialPath"].ToString()));
            }
            return carList;
        }
    }
}
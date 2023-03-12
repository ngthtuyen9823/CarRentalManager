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

namespace CarRentalManager.ViewModel
{
    public class ListCarViewModel
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        private ObservableCollection<Car> list;
        //public ObservableCollection<Car> List { get => list; set { list = value; OnPropertyChanged(); } }
        public ObservableCollection<Car> List {get; set;}

        public ListCarViewModel()
        {
            getListObservableCar();
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
        public List<Car> getListCar()
        {

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT *FROM Car", conn);

            DataTable dataTableCar = new DataTable();
            adapter.Fill(dataTableCar);
            List<Car> carList = new List<Car>();
            for (int i = 0; i < dataTableCar.Rows.Count; i++)
            {
                var row = dataTableCar.Rows[i];
                ECarStatus status;
                Enum.TryParse<ECarStatus>(row["status"].ToString(), out status);
                ECarType type;
                Enum.TryParse<ECarType>(row["type"].ToString(), out type);
                EDrivingType drivingType;
                Enum.TryParse<EDrivingType>(row["drivingType"].ToString(), out drivingType);

                Car car = new Car(
                    Convert.ToInt32(row["id"]),
                    row["name"].ToString(),
                    row["branch"].ToString(),
                    Convert.ToInt32(row["publishYear"]),
                    row["color"].ToString(),
                    Convert.ToInt32(row["price"]),
                   status,
                   type,
                   drivingType,
                    Convert.ToInt32(row["seats"]),
                    row["licensePlate"].ToString(),
                    row["imagePath"].ToString(),
                    row["tutorialPath"].ToString());

                carList.Add(car);
               
            }
            return carList;
        }
        public void  getListObservableCar()
        {

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT *FROM Car", conn);
            DataTable dataTableCar = new DataTable();
            adapter.Fill(dataTableCar);
            List<Car> carList = new List<Car>();
            for (int i = 0; i < dataTableCar.Rows.Count; i++)
            {
                var row = dataTableCar.Rows[i];
                ECarStatus status;
                Enum.TryParse<ECarStatus>(row["status"].ToString(), out status);
                ECarType type;
                Enum.TryParse<ECarType>(row["type"].ToString(), out type);
                EDrivingType drivingType;
                Enum.TryParse<EDrivingType>(row["drivingType"].ToString(), out drivingType);

                Car car = new Car(
                    Convert.ToInt32(row["id"]),
                    row["name"].ToString(),
                    row["branch"].ToString(),
                    Convert.ToInt32(row["publishYear"]),
                    row["color"].ToString(),
                    Convert.ToInt32(row["price"]),
                   status,
                   type,
                   drivingType,
                    Convert.ToInt32(row["seats"]),
                    row["licensePlate"].ToString(),
                    row["imagePath"].ToString(),
                    row["tutorialPath"].ToString());

                carList.Add(car);

            }
            List = new ObservableCollection<Car>(carList);

        }
    }
}
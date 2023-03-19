using CarRentalManager.enums;
using CarRentalManager.services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using CarRentalManager.modals;
using System.Diagnostics;
using System.Xml.Linq;
using System.Collections.ObjectModel;

namespace CarRentalManager.dao
{
    public class CarDAO
    {
        private SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        readonly SqlQueryService sqlService = new SqlQueryService();
        readonly CarDataService carDataService= new CarDataService();
        public CarDAO() { }

        public List<Car> getListCarFromDataTable(DataTable dataTable)
        {
            List<Car> carList = new List<Car>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var row = dataTable.Rows[i];
                Car newCar = carDataService.createCarByRowData(row);
                carList.Add(newCar);
            }
            return carList;
        }

        public List<Car> getListCar()
        {
            try
            {
                conn.Open();
                string sqlStringGetTable = sqlService.getListTableData(ETableName.CAR);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStringGetTable, conn);
                DataTable dataTableCar = new DataTable();
                adapter.Fill(dataTableCar);

                return getListCarFromDataTable(dataTableCar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally { 
                conn.Close();
            }
        }
        public void addCarToList(int ID, string Name, string Brand, string Type, string Status, string LicensePlate, int Price)
        {
            try
            {
                conn.Open();
                string SQL = sqlService.createNewCar(ID, Name, Brand, Type, Status, LicensePlate, Price);
                SqlCommand cmd = new SqlCommand(SQL, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Success!");
                    string sqlStringGetTable = sqlService.getListTableData(ETableName.CAR);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlStringGetTable, conn);
                    DataTable dataTableCar = new DataTable();
                    adapter.Fill(dataTableCar);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail!" + ex);
            }
            finally
            {
                conn.Close();
            }

        }

        public List<Car> getListCarByDescOrAsc(bool isDescrease, string fieldName)
        {
            try
            {
                conn.Open();
                string sqlStringGetTable = sqlService.getSortByDescOrAsc(isDescrease, fieldName, ETableName.CAR);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStringGetTable, conn);
                DataTable dataTableCar = new DataTable();
                adapter.Fill(dataTableCar);

                return getListCarFromDataTable(dataTableCar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public Car getCarById(string id)
        {
            try
            {
                conn.Open();
                string sqlStringGetTable = sqlService.getValueById(id, ETableName.CAR);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStringGetTable, conn);
                DataTable dataTableCar = new DataTable();
                adapter.Fill(dataTableCar);

                Car newCar = carDataService.createCarByRowData(dataTableCar.Rows[0]);
                return newCar;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Car> getListCarByType(ECarType eCarType)
        {
            try
            {
                conn.Open();
                string sqlStringGetTable = sqlService.getListCarByType(eCarType);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStringGetTable, conn);
                DataTable dataTableCar = new DataTable();
                adapter.Fill(dataTableCar);

                return getListCarFromDataTable(dataTableCar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        
    }
}

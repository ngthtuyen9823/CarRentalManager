using CarRentalManager.enums;
using CarRentalManager.services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CarRentalManager.modals;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using MaterialDesignThemes.Wpf;
using System.Net;
using System.Xml.Linq;

namespace CarRentalManager.dao
{
    public class CustomerDAO
    {
        private SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        readonly SqlQueryService sqlService = new SqlQueryService();
        readonly CustomerDataService customerDataService = new CustomerDataService();
        public CustomerDAO() { }

        public List<Customer> getListCustomer()
        {
            try
            {
                conn.Open();
                string sqlStringGetTable = sqlService.getListTableData(ETableName.CUSTOMER);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStringGetTable, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                List<Customer> customerList = new List<Customer>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    var row = dataTable.Rows[i];
                    Customer newCustomer = customerDataService.createCustomerByRowData(row);
                    customerList.Add(newCustomer);
                }
                return customerList;
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
        public void addCustomerToList(int id, string name, string phoneNumber, string email, string idCard, string address, DateTime createdAt, DateTime updatedAt)
        {
            try
            {
                conn.Open();
                string SQL = sqlService.createNewCustomer(id, name, phoneNumber, email, idCard, address, createdAt, updatedAt);
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
        public void removeCustomerFromList(int id)
        {
            try
            {
                conn.Open();
                string SQL = sqlService.removeCustomer(id);
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
    
        public List<Customer> getListCustomerByDescOrAsc(bool isDescrease, string fieldName)
        {
            try
            {
                conn.Open();
                string sqlStringGetTable = sqlService.getSortByDescOrAsc(isDescrease, fieldName, ETableName.CUSTOMER);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStringGetTable, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                List<Customer> customerList = new List<Customer>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    var row = dataTable.Rows[i];
                    Customer newCustomer = customerDataService.createCustomerByRowData(row);
                    customerList.Add(newCustomer);
                }
                return customerList;
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

        public Customer getCustomerById(string id)
        {
            try
            {
                conn.Open();
                string sqlStringGetTable = sqlService.getValueById(id, ETableName.CUSTOMER);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStringGetTable, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                Customer newCustomer = customerDataService.createCustomerByRowData(dataTable.Rows[0]);
                return newCustomer;
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

        public void createNewCustomer(int id, string phoneNumber, string name, string email, string idCard, string address, string imageIdCardFront, string imageIdCardBack)
        {
            try
            {
                conn.Open();
                string sqlQuery = sqlService.createNewCustomer(id, phoneNumber, name, email, idCard, address, imageIdCardFront, imageIdCardBack);
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    string sqlStringGetTable = sqlService.getListTableData(ETableName.CUSTOMER);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlStringGetTable, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

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
                    Customer newCustomer = customerDataService.craeteCustomerByRowData(row);
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
                    Customer newCustomer = customerDataService.craeteCustomerByRowData(row);
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

                Customer newCustomer = customerDataService.craeteCustomerByRowData(dataTable.Rows[0]);
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

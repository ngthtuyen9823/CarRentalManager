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
    public class SupplierDAO
    {
        private SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        readonly SqlQueryService sqlService = new SqlQueryService();
        readonly SupplierDataService supplierDataService = new SupplierDataService();
        public SupplierDAO() { }

        public List<Supplier> getListSupplier()
        {
            try
            {
                conn.Open();
                string sqlStringGetTable = sqlService.getListTableData(ETableName.SUPPLIER);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStringGetTable, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                List<Supplier> supplierList = new List<Supplier>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    var row = dataTable.Rows[i];
                    Supplier newSupplier = supplierDataService.createSupplierByRowData(row);
                    supplierList.Add(newSupplier);
                }
                return supplierList;
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
        public void addSupplierToList(int id, string name, string phoneNumber, string email, string address)
        {
            try
            {
                conn.Open();
                string SQL = sqlService.createNewSupplier(id, name, phoneNumber, email, address);
                SqlCommand cmd = new SqlCommand(SQL, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Success!");
                    string sqlStringGetTable = sqlService.getListTableData(ETableName.SUPPLIER);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlStringGetTable, conn);
                    DataTable dataTableSupplier = new DataTable();
                    adapter.Fill(dataTableSupplier);

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
        public void createNewSupplier(int id, string name, string phoneNumber, string email, string address)
        {
            try
            {
                conn.Open();
                string sqlQuery = sqlService.createNewSupplier(id, name, phoneNumber, email, address);
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    string sqlStringGetTable = sqlService.getListTableData(ETableName.SUPPLIER);
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

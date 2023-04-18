using CarRentalManager.enums;
using CarRentalManager.services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CarRentalManager.models;
using System.Diagnostics;
using System.Security.Policy;
using System.Windows.Media;
using System.Xml.Linq;

namespace CarRentalManager.dao
{
    public class DbConnectionDAO
    {
        private SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        readonly SqlQueryService sqlService = new SqlQueryService();
        readonly VariableService variableService = new VariableService();

        public DbConnectionDAO() { }


        public DataTable getDataTable (string sqlString)
        {
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlString, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail!" + ex);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public void executing(string sqlString, ETableName tableName)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    string sqlStringGetTable = sqlService.getListTableData(tableName);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlStringGetTable, conn);
                    DataTable dataTableCar = new DataTable();
                    adapter.Fill(dataTableCar);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail!" + ex);
                throw new Exception();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

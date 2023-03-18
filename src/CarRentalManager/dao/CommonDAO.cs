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

namespace CarRentalManager.dao
{
    public class CommonDAO
    {
        private SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        readonly SqlQueryService sqlService = new SqlQueryService();
        readonly VariableService variableService = new VariableService();

        public CommonDAO() { }

        public int getLastId(ETableName eTableName)
        {
            try
            {
                conn.Open();

                string sqlStringGetTable = sqlService.getLastId(eTableName);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStringGetTable, conn);
                DataTable dataTableOrder = new DataTable();
                adapter.Fill(dataTableOrder);

                int id = variableService.parseStringToInt(dataTableOrder.Rows[0]["id"].ToString());
                return id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail!" + ex);
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

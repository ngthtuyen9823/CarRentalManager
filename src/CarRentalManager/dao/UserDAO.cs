using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using CarRentalManager.modals;
using CarRentalManager.services;

namespace CarRentalManager.dao
{
    public class UserDAO
    {
        private SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        readonly SqlQueryService sqlService = new SqlQueryService();
        readonly UserDataService userDataService = new UserDataService();
        public UserDAO() { }

        public User getUserWithEmail(string email)
        {
            try
            {
                conn.Open();
                string sqlStringGetTable = sqlService.getUserWithEmail(email);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStringGetTable, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                User currentUser = userDataService.createUserByRowData(dataTable.Rows[0]);
                return currentUser;
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

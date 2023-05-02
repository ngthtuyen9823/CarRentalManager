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

using System.Diagnostics;
using System.Security.Policy;
using System.Windows.Media;
using System.Xml.Linq;
using System.Data.Entity.Core.EntityClient;

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
            using (var db = new CRMContext())
            {
                var blog = new Blog
                {
                    id = 1,
                    name = "Blog ve hoc sinh"
                };
                db.Posts.Add(blog);
                db.SaveChanges();

                var query = from q in db.Posts
                            select q;
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

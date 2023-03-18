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
    public class OrderDAO
    {
        private SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        readonly SqlQueryService sqlService = new SqlQueryService();
        readonly OrderDataService orderDataService= new OrderDataService();
        readonly VariableService variableService = new VariableService();
        public OrderDAO() { }

        public List<Order> getListOrder()
        {
            try
            {
                conn.Open();
                string sqlStringGetTable = sqlService.getListTableData(ETableName.ORDER);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStringGetTable, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                List<Order> orderList = new List<Order>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    var row = dataTable.Rows[i];
                    Order newOrder = orderDataService.craeteOrderByRowData(row);
                    orderList.Add(newOrder);
                }
                return orderList;
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
        public void addOrderToList(int ID, int CarId, int CustomerId, string BookingPlace, DateTime StartDate, DateTime EndDate, int TotalFee)
        {
            try
            {
                conn.Open();
                string SQL = sqlService.createOrder( ID, CarId, CustomerId, BookingPlace, StartDate, EndDate, TotalFee);
                SqlCommand cmd = new SqlCommand(SQL, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    string sqlStringGetTable = sqlService.getListTableData(ETableName.ORDER);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlStringGetTable, conn);
                    DataTable dataTableOrder = new DataTable();
                    adapter.Fill(dataTableOrder);

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
        public int getLastId(ETableName eTableName)
        {
            try
            {
                conn.Open();
                
                MessageBox.Show("inside");
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

        public List<Order> getListOrderByDescOrAsc(bool isDescrease, string fieldName)
        {
            try
            {
                conn.Open();
                string sqlStringGetTable = sqlService.getSortByDescOrAsc(isDescrease, fieldName, ETableName.ORDER);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStringGetTable, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                List<Order> orderList = new List<Order>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    var row = dataTable.Rows[i];
                    Order newOrder = orderDataService.craeteOrderByRowData(row);
                    orderList.Add(newOrder);
                }
                return orderList;
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

        public Order getOrderById(string id)
        {
            try
            {
                conn.Open();
                string sqlStringGetTable = sqlService.getValueById(id, ETableName.ORDER);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStringGetTable, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                Order newOrder = orderDataService.craeteOrderByRowData(dataTable.Rows[0]);
                return newOrder;
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

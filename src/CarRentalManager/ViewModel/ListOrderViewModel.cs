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
using CarRentalManager.services;

namespace CarRentalManager.ViewModel
{
    public class ListOrderViewModel : BaseViewModel
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        SqlQueryService sqlService = new SqlQueryService();
        private ObservableCollection<Order> list;
        public ObservableCollection<Order> List { get; set; }
        readonly VariableService variableService = new VariableService();
        readonly OrderDataService orderDataService = new OrderDataService();
        public ListOrderViewModel()
        {
            List = getListObservableOrder();
        }
        public ObservableCollection<Order> getListObservableOrder()
        {
            string sqlStringGetTable = sqlService.getListTableData(ETableName.ORDER); 
            SqlDataAdapter adapter = new SqlDataAdapter(sqlStringGetTable, conn);
            DataTable dataTableOrder = new DataTable();
            adapter.Fill(dataTableOrder);

            ObservableCollection<Order> orderList = new ObservableCollection<Order>();
            for (int i = 0; i < dataTableOrder.Rows.Count; i++)
            {
                var row = dataTableOrder.Rows[i];
                Order newOrder = orderDataService.craeteOrderByRowData(row);
                orderList.Add(newOrder);
            }
            return orderList;
        }
    }
}

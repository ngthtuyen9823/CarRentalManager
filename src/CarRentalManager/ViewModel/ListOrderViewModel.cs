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
                int id;
                int carId;
                int customerId;
                int totalFee;

                EOrderStatus status;
                DateTime startDate;
                DateTime endDate;
                DateTime createdAt;
                DateTime updatedAt;

                var row = dataTableOrder.Rows[i];
                int.TryParse(row["id"].ToString(), out id);
                int.TryParse(row["carId"].ToString(), out carId);
                int.TryParse(row["customerId"].ToString(), out customerId);
                int.TryParse(row["totalFee"].ToString(), out totalFee);

                Enum.TryParse<EOrderStatus>(row["status"].ToString(), out status);

                createdAt = DateTime.Parse(row["createdAt"].ToString());
                updatedAt = DateTime.Parse(row["updatedAt"].ToString());
                startDate = DateTime.Parse(row["startDate"].ToString());
                endDate = DateTime.Parse(row["endDate"].ToString());

                orderList.Add(
                    new Order(id,
                    carId,
                    customerId,
                    row["bookingPlace"].ToString(),
                    startDate,
                    endDate,
                    totalFee,
                    status,
                    createdAt, 
                    updatedAt));
            }
            return orderList;
        }
    }
}

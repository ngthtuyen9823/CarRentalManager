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
    public class ListContractViewModel : BaseViewModel
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        SqlQueryService sqlService = new SqlQueryService();
        private ObservableCollection<Contract> list;
        public ObservableCollection<Contract> List { get; set; }
        public ListContractViewModel()
        {
            List = getListObservableContract();
        }
        public ObservableCollection<Contract> getListObservableContract()
        {
            string sqlStringGetTable = sqlService.getListTableData(ETableName.CONTRACT);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlStringGetTable, conn);
            DataTable dataTableContract = new DataTable();
            adapter.Fill(dataTableContract);

            ObservableCollection<Contract> contractList = new ObservableCollection<Contract>();
            for (int i = 0; i < dataTableContract.Rows.Count; i++)
            {
                int id;
                int orderId;
                int userId;

                DateTime makingDay;
                DateTime createdAt;
                DateTime updatedAt;

                var row = dataTableContract.Rows[i];
                int.TryParse(row["id"].ToString(), out id);
                int.TryParse(row["orderId"].ToString(), out orderId);
                int.TryParse(row["userId"].ToString(), out userId);

                makingDay = DateTime.Parse(row["makingDay"].ToString());
                createdAt = DateTime.Parse(row["createdAt"].ToString());
                updatedAt = DateTime.Parse(row["updatedAt"].ToString());

                contractList.Add(
                    new Contract(id,
                    orderId,
                    userId,
                    makingDay,
                    createdAt,
                    updatedAt));
            }
            return contractList;
        }
    }
}

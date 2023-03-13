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
using System.Diagnostics;
using System.Security.Policy;
using System.Globalization;

namespace CarRentalManager.ViewModel
{
    public class ListCustomerViewModel : BaseViewModel
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        SqlQueryService sqlService = new SqlQueryService();
        private ObservableCollection<Customer> list;
        public ObservableCollection<Customer> List { get; set; }
        readonly CustomerDataService customerDataService = new CustomerDataService();
        public ListCustomerViewModel() 
        {
            List = getListObservableCustomer();
        }
        public ObservableCollection<Customer> getListObservableCustomer()
        {
            string sqlStringGetTable = sqlService.getListTableData(ETableName.CUSTOMER); ////
            SqlDataAdapter adapter = new SqlDataAdapter(sqlStringGetTable, conn);
            DataTable dataTableCustomer = new DataTable();
            adapter.Fill(dataTableCustomer);

            ObservableCollection<Customer> customerList = new ObservableCollection<Customer>();
            for (int i = 0; i < dataTableCustomer.Rows.Count; i++)
            {
                var row = dataTableCustomer.Rows[i];
                Customer newCustomer = customerDataService.craeteCustomerByRowData(row);
                customerList.Add(newCustomer);
            }
            return customerList;
        }
    }
}

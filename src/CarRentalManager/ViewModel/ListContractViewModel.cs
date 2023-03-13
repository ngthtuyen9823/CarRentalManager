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
        readonly VariableService variableService = new VariableService();
        readonly ContractDataService contractDataService = new ContractDataService();
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
                var row = dataTableContract.Rows[i];
                Contract newContract = contractDataService.craeteContractByRowData(row);
                contractList.Add(newContract);
            }
            return contractList;
        }
    }
}

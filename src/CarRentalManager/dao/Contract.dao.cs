using CarRentalManager.enums;
using CarRentalManager.modals;
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
    public class ContractDao
    {
        private SqlConnection conn;
        readonly SqlQueryService sqlService = new SqlQueryService();
        readonly ContractDataService contractDataService = new ContractDataService();
        public ContractDao() { }

        public Contract getContractById(string id)
        {
            try
            {
                conn = new SqlConnection(Properties.Settings.Default.connStr);
                string sqlStringGetTable = sqlService.getValueWithId(id, ETableName.CAR);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStringGetTable, conn);
                DataTable dataTableCar = new DataTable();
                adapter.Fill(dataTableCar);

                Contract newCar = contractDataService.createContractByRowData(dataTableCar.Rows[0]);
                return newCar;
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

        public List<Contract> getListCar()
        {
            try
            {
                conn.Open();
                string sqlStringGetTable = sqlService.getListTableData(ETableName.CAR);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStringGetTable, conn);
                DataTable dataTableCar = new DataTable();
                adapter.Fill(dataTableCar);

                List<Contract> contractList = new List<Contract>();
                for (int i = 0; i < dataTableCar.Rows.Count; i++)
                {
                    var row = dataTableCar.Rows[i];
                    Contract newContract = contractDataService.createContractByRowData(row);
                    contractList.Add(newContract);
                }
                return contractList;
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

        public List<Contract> getListContractByDescOrAsc(bool isDescrease, string fieldName)
        {
            try
            {
                conn.Open();
                string sqlStringGetTable = sqlService.getSortByDescOrAsc(isDescrease, fieldName, ETableName.CONTRACT);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStringGetTable, conn);
                DataTable dataTableCar = new DataTable();
                adapter.Fill(dataTableCar);

                List<Contract> contractList = new List<Contract>();
                for (int i = 0; i < dataTableCar.Rows.Count; i++)
                {
                    var row = dataTableCar.Rows[i];
                    Contract newContract = contractDataService.createContractByRowData(row);
                    contractList.Add(newContract);
                }
                return contractList;
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


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
using CarRentalManager.models;
using System.Diagnostics;
using System.Security.Policy;
using System.Windows.Media;
using System.Xml.Linq;

namespace CarRentalManager.dao
{
    public class CommonDAO
    {
        private SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        readonly SqlQueryService sqlService = new SqlQueryService();
        readonly VariableService variableService = new VariableService();
        readonly DbConnectionDAO dbConnectionDAO = new DbConnectionDAO();

        public CommonDAO() { }

        public int getLastId(ETableName eTableName)
        {
            string sqlStringGetTable = sqlService.getLastId(eTableName);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            if (dataTable.Rows.Count == 0)
            {
                return 0;
            }
            int id = variableService.parseStringToInt(dataTable.Rows[0][nameof(id)].ToString());
            return id;
        }

        public DataTable countOnrentTimes()
        {
            string sqlStringGetTable = sqlService.countOnrentTimes();
            MessageBox.Show(sqlStringGetTable);
            return dbConnectionDAO.getDataTable(sqlStringGetTable);
            
        }

        public DataTable countBrokenTimes()
        {
            string sqlStringGetTable = sqlService.countBrokenTimes();
            return dbConnectionDAO.getDataTable(sqlStringGetTable);
           
        }
    }
}

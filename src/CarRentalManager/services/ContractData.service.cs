using CarRentalManager.enums;
using CarRentalManager.modals;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManager.services
{
    public class ContractDataService
    {
        private readonly VariableService variableService = new VariableService();
        public ContractDataService() { }

        public Contract craeteContractByRowData(DataRow row)
        {
            DateTime makingDay = DateTime.Parse(row["makingDay"].ToString());
            int id = variableService.parseStringToInt(row["id"].ToString());
            int orderId = variableService.parseStringToInt(row["orderId"].ToString());
            int userId = variableService.parseStringToInt(row["userId"].ToString());

             return new Contract(id,
                orderId,
                userId,
                makingDay);
        }
    }
}

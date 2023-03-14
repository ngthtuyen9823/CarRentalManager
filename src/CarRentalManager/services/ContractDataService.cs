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

<<<<<<< CRM-18:src/CarRentalManager/services/ContractDataService.cs
        public Contract createContractByRowData(DataRow row)
=======
        public Contract craeteContractByRowData(DataRow row) 
>>>>>>> CRM-19 | Add addcomand to customer table:src/CarRentalManager/services/ContractData.service.cs
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

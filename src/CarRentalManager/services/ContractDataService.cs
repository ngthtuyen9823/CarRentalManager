using CarRentalManager.enums;
using CarRentalManager.modals;
using System;
using System.Data;

namespace CarRentalManager.services
{
    public class ContractDataService
    {
        private readonly VariableService variableService = new VariableService();
        public ContractDataService() { }

        public Contract createContractByRowData(DataRow row)
        {
            DateTime makingDay = DateTime.Parse(row["makingDay"].ToString());
            int id = variableService.parseStringToInt(row["id"].ToString());
            int orderId = variableService.parseStringToInt(row["orderId"].ToString());
            int userId = variableService.parseStringToInt(row["userId"].ToString());
            EContractStatus status = variableService.parseStringToEnum<EContractStatus>(row["status"].ToString());

             return new Contract(id,
                orderId,
                userId,
                makingDay,
                status);
        }
    }
}

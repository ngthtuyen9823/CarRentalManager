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
    public class OrderDataService
    {
        private readonly VariableService variableService = new VariableService();
        public OrderDataService() { }

        public Order craeteOrderByRowData(DataRow row)
        {
            DateTime startDate = DateTime.Parse(row["startDate"].ToString());
            DateTime endDate = DateTime.Parse(row["endDate"].ToString()); ;
            int id = variableService.parseStringToInt(row["id"].ToString());
            int carId = variableService.parseStringToInt(row["carId"].ToString());
            int customerId = variableService.parseStringToInt(row["customerId"].ToString());
            int totalFee = variableService.parseStringToInt(row["totalFee"].ToString());
            int depositAmount = variableService.parseStringToInt(row["depositAmount"].ToString());
            EOrderStatus status = variableService.parseStringToEnum<EOrderStatus>(row["status"].ToString());
            DateTime createdAt = DateTime.Parse(row["createdAt"].ToString());
            DateTime updatedAt = DateTime.Parse(row["updatedAt"].ToString());

            return new Order(id,
                carId,
                customerId,
                row["bookingPlace"].ToString(),
                startDate,
                endDate,
                totalFee,
                status,
                depositAmount,
                row["imageEvidence"].ToString(),
                row["notes"].ToString(),
                createdAt, updatedAt);
        }
    }
}

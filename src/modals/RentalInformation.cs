using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManager.modals
{
    public class RentalInformation
    {
        string id;
        string carId;
        string userId;
        DateTime startDate;
        DateTime endDate;
        string totalFee;
        ERentalInformationStatus status;
        DateTime createdAt;
        DateTime updatedAt;

        public RentalInformation(string id,
        string carId,
        string userId,
        DateTime startDate,
        DateTime endDate,
        string totalFee,
        ERentalInformationStatus status,
        DateTime createdAt,
        DateTime updatedAt)
        {
            this.id = id;
            this.carId = carId;
            this.userId = userId;
            this.startDate = startDate;
            this.endDate = endDate;
            this.totalFee = totalFee;
            this.status = status;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
        }
    }
}

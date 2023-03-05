using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalManager.enums;

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

        public string ID { get { return id; } }
        public string CarId { get { return carId; } }
        public string UserId { get { return userId; } }
        public DateTime StartDate { get { return startDate; } }
        public DateTime EndDate { get { return endDate; } }
        public string TotalFee { get { return totalFee; } }
        public ERentalInformationStatus Status { get { return status; } }
        public DateTime CreatedAt { get { return createdAt; } }
        public DateTime UpdatedAt { get { return updatedAt; } }


    }
}

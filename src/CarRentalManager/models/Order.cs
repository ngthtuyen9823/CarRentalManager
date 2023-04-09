using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalManager.enums;

namespace CarRentalManager.models
{
    public class Order
    {
        int id;
        int carId;
        int customerId;
        string bookingPlace;
        DateTime startDate;
        DateTime endDate;
        int totalFee;
        EOrderStatus status;
        int depositAmount;
        string imageEvidence;
        string notes;
        DateTime createdAt;
        DateTime updatedAt;
        public Order(int id,
        int carId,
        int customerId,
        string bookingPlace,
        DateTime startDate,
        DateTime endDate,
        int totalFee,
        EOrderStatus status,
        int depositAmount,
        string imageEvidence,
        string notes,
        DateTime createdAt,
        DateTime updatedAt)
        {
            this.id = id;
            this.carId = carId;
            this.customerId = customerId;
            this.bookingPlace = bookingPlace;
            this.startDate = startDate;
            this.endDate = endDate;
            this.totalFee = totalFee;
            this.status = status;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
            this.depositAmount = depositAmount;
            this.imageEvidence = imageEvidence;
            this.notes = notes;
        }

        public Order() { }

        public int ID { get { return id; } set { id = value; } }
        public int CarId { get { return carId; } set { carId = value; } }
        public int CustomerId { get { return customerId; } set { customerId = value; } }
        public string BookingPlace { get { return bookingPlace; } set { bookingPlace = value; } }
        public DateTime StartDate { get { return startDate; } set { startDate = value; } }
        public DateTime EndDate { get { return endDate; } set { endDate = value; } }
        public int TotalFee { get { return totalFee; } set { totalFee = value; } }
        public EOrderStatus Status { get { return status; } set { status = value; } }
        public int DepositAmount { get { return depositAmount; } set { depositAmount = value; } }
        public string ImageEvidence { get { return imageEvidence; } set { imageEvidence = value; } }
        public string Notes { get { return notes; } set { notes = value; } }
        public DateTime CreatedAt { get { return createdAt; } set { createdAt = value; } }
        public DateTime UpdatedAt { get { return updatedAt; } set { updatedAt = value; } }


    }
}

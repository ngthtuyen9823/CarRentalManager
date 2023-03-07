using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalManager.enums;

namespace CarRentalManager.modals
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
        }

        public int ID { get { return id; } }
        public int CarId { get { return carId; } }
        public int CustomerId { get { return customerId; } }
        public string BookingPlace { get { return bookingPlace; } }
        public DateTime StartDate { get { return startDate; } }
        public DateTime EndDate { get { return endDate; } }
        public int TotalFee { get { return totalFee; } }
        public EOrderStatus Status { get { return status; } }
        public DateTime CreatedAt { get { return createdAt; } }
        public DateTime UpdatedAt { get { return updatedAt; } }


    }
}

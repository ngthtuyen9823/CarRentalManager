//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarRentalManager
{
    using CarRentalManager.enums;
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        private int id;
        private Nullable<int> carId;
        private Nullable<int> customerId;
        private string bookingPlace;
        private Nullable<System.DateTime> startDate;
        private Nullable<System.DateTime> endDate;
        private Nullable<int> totalFee;
        private string status;
        private Nullable<int> depositAmount;
        private string imageEvidence;
        private string notes;
        private Nullable<System.DateTime> createdAt;
        private Nullable<System.DateTime> updatedAt;

        public int ID { get { return id; } set { id = value; } }
        public Nullable<int> CarId { get { return carId; } set { carId = value; } }
        public Nullable<int> CustomerId { get { return customerId; } set { customerId = value; } }
        public string BookingPlace { get { return bookingPlace; } set { bookingPlace = value; } }
        public Nullable<System.DateTime> StartDate { get { return startDate; } set { startDate = value; } }
        public Nullable<System.DateTime> EndDate { get { return endDate; } set { endDate = value; } }
        public Nullable<int> TotalFee { get { return totalFee; } set { totalFee = value; } }
        public string Status { get { return status; } set { status = value; } }
        public Nullable<int> DepositAmount { get { return depositAmount; } set { depositAmount = value; } }
        public string ImageEvidence { get { return imageEvidence; } set { imageEvidence = value; } }
        public string Notes { get { return notes; } set { notes = value; } }
        public Nullable<System.DateTime> CreatedAt { get { return createdAt; } set { createdAt = value; } }
        public Nullable<System.DateTime> UpdatedAt { get { return updatedAt; } set { updatedAt = value; } }
    }
}

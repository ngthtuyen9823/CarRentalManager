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
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int id { get; set; }
        public Nullable<int> carId { get; set; }
        public Nullable<int> customerId { get; set; }
        public string bookingPlace { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public Nullable<int> totalFee { get; set; }
        public string status { get; set; }
        public Nullable<int> depositAmount { get; set; }
        public string imageEvidence { get; set; }
        public string notes { get; set; }
        public Nullable<System.DateTime> createdAt { get; set; }
        public Nullable<System.DateTime> updatedAt { get; set; }
    }
}
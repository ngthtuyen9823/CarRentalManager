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
    
    public partial class Car
    {
        public int id { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public string color { get; set; }
        public string publishYear { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string drivingType { get; set; }
        public Nullable<int> seats { get; set; }
        public string licensePlate { get; set; }
        public Nullable<int> price { get; set; }
        public string imagePath { get; set; }
        public string tutorialPath { get; set; }
        public string city { get; set; }
        public Nullable<int> supplierId { get; set; }
        public Nullable<System.DateTime> createdAt { get; set; }
        public Nullable<System.DateTime> updatedAt { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Planning.Data
{
    using System;
    
    public partial class rpDI004_Result
    {
        public decimal ZvenoID { get; set; }
        public string ZvenoName { get; set; }
        public string OrdersDate { get; set; }
        public string Diet { get; set; }
        public string StartDate { get; set; }
        public int Duration { get; set; }
        public string DeliveryDate { get; set; }
        public Nullable<int> DietCurrentDay { get; set; }
        public Nullable<int> OrderBreakfast { get; set; }
        public Nullable<int> OrderLunch { get; set; }
        public Nullable<int> OrderDinner { get; set; }
        public Nullable<int> OrderAllDay { get; set; }
        public string OrderExtremelyDeliveryDate { get; set; }
        public Nullable<int> ExtremelyCurrentDay { get; set; }
        public Nullable<int> OrderExtremelyDinner { get; set; }
        public int PatientsByWard { get; set; }
        public Nullable<decimal> OrderTotalPrice { get; set; }
        public string DeliveryDescription { get; set; }
        public Nullable<int> DeliveryBreakfast { get; set; }
        public Nullable<int> DeliveryLunch { get; set; }
        public Nullable<int> DeliveryDinner { get; set; }
        public Nullable<int> DeliveryAllDay { get; set; }
        public Nullable<int> DeliveryExtremelyDinner { get; set; }
        public Nullable<decimal> DeliveryTotalPrice { get; set; }
        public Nullable<int> DifferenceBreakfast { get; set; }
        public Nullable<int> DifferenceLunch { get; set; }
        public Nullable<int> DifferenceDinner { get; set; }
        public Nullable<int> DifferenceAllDay { get; set; }
        public Nullable<int> DifferenceExtremelyDinner { get; set; }
        public Nullable<decimal> DifferenceTotalPrice { get; set; }
        public Nullable<int> BreakfastMinorDiscrepancy { get; set; }
        public Nullable<int> BreakfastMajorDiscrepancy { get; set; }
        public Nullable<int> LunchMinorDiscrepancy { get; set; }
        public Nullable<int> LunchMajorDiscrepancy { get; set; }
        public Nullable<int> DinnerMinorDiscrepancy { get; set; }
        public Nullable<int> DinnerMajorDiscrepancy { get; set; }
        public Nullable<int> AllDayMinorDiscrepancy { get; set; }
        public Nullable<int> AllDayMajorDiscrepancy { get; set; }
        public Nullable<int> ExtremelyDinnerMinorDiscrepancy { get; set; }
        public Nullable<int> ExtremelyDinnerMajorDiscrepancy { get; set; }
    }
}
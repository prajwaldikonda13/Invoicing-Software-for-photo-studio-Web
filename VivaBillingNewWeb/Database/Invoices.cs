using System;

namespace VivaBillingNewWeb.Database
{
    public class Invoices
    {
        public long ID { get; set; }
        //public string Date { get; set; }
        public DateTime DateTime { get; set; }
        //public string Time { get; set; }
        public float FinalPrice { get; set; }
        public float Paid { get; set; }
        public float Discount { get; set; }
        public float PrevBal { get; set; }
        public float CurrentBal { get; set; }
        //public float Due { get; set; }
        public long customer { get; set; }
    }
}
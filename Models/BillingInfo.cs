using System;
namespace billing.Models
{
    public class BillingInfo
    {
        public decimal amount { get; set; }
        public decimal amount_real { get; set; }
        public DateTime issue_date { get; set; }
        public string bill_reference { get; set; } = "";
        public string month { get; set; } = ""; 
        public decimal Cost { get; set; }

        public string? IdNo { get; set; }

        public bool disable_manualpay { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LefeWareLearning.TenantBilling.Models
{
    public class MonthlyBill
    {
        public DateTime BillingPeriod { get; set; }

        public bool Paid { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public PaymentMethods PaymentMethod { get; set; }

        public MonthlyBill(DateTime billingPeriod, string description, decimal amount, PaymentMethods paymentMethod)
        {
            BillingPeriod = billingPeriod;
            Paid = true;
            Description = description;
            Amount = amount;
            PaymentMethod = paymentMethod;
        }
    }
}

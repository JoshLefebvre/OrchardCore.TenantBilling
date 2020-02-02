using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.TenantBilling.Models;

namespace LefeWareLearning.TenantBilling.Models
{
    public class MonthlyBill
    {
        public BillingPeriod BillingPeriod { get; set; }

        public bool Paid { get; set; } //Todo switch to status enum

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public CreditCardInformation CreditCardInfo { get; set; }

        public MonthlyBill(BillingPeriod billingPeriod, string description, decimal amount, CreditCardInformation creditCardInfo)
        {
            BillingPeriod = billingPeriod;
            Paid = true;
            Description = description;
            Amount = amount;
            CreditCardInfo = creditCardInfo;
        }
    }
}

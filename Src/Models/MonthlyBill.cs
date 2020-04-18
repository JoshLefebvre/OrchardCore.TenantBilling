using OrchardCore.TenantBilling.Models;

namespace OrchardCore.TenantBilling.Models
{
    public class MonthlyBill
    {
        public BillingPeriod BillingPeriod { get; private set; }

        public PaymentStatus PaymentStatus { get; private set; } 

        public string Description { get; private set; }

        public decimal Amount { get; private set; }

        public CreditCardInformation CreditCardInfo { get; private set; }

        public MonthlyBill(BillingPeriod billingPeriod, string description, PaymentStatus status, decimal amount, CreditCardInformation creditCardInfo)
        {
            BillingPeriod = billingPeriod;
            PaymentStatus = status;
            Description = description;
            Amount = amount;
            CreditCardInfo = creditCardInfo;
        }
    }
}

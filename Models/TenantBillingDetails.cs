using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.TenantBilling.Models;

namespace LefeWareLearning.TenantBilling.Models
{
    public class TenantBillingDetails
    {
        public string TenantId { get; private set; }

        public string TenantName { get; private set; }

        public List<PaymentMethod> SubscriptionPaymentMethods { get; private set; }

        public List<MonthlyBill> BillingHistory { get; private set; }

        public TenantBillingDetails(string tenantId, string tenantName)
        {
            TenantId = tenantId;
            TenantName = tenantName;
            BillingHistory = new List<MonthlyBill>();
            SubscriptionPaymentMethods = new List<PaymentMethod>();
        }

        public void AddNewPaymentMethod(PaymentMethod paymentMethod)
        {
            //TODO: Itterate through list to ensure only one "active" payment type at a time
            SubscriptionPaymentMethods.Add(paymentMethod);
        }

        public bool IsNewPaymentMethod(PaymentMethod paymentMethod)
        {
           //TODO: Add logic for comparing a credit card
           return true;
        }

        public void AddMonthlyBill(BillingPeriod billingPeriod, decimal amount, CreditCardInformation creditCardInfo)
        {
            BillingHistory.Add(
                new MonthlyBill(billingPeriod, TeanantBillingConstants.PaymentPlans.MonthlySubscription, amount, creditCardInfo)
            );
        }
    }
}

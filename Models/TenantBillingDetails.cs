using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LefeWareLearning.TenantBilling.Models
{
    public class TenantBillingDetails
    {
        public string TenantId { get; set; }

        public List<PaymentInformation> PaymentInformation { get; set; }

        public List<MonthlyBill> BillingHistory { get; set; }

        public TenantBillingDetails(string tenantId)
        {
            TenantId = tenantId;
            BillingHistory = new List<MonthlyBill>();
        }

        public void AddMonthlyBill(DateTime billingPeriod, decimal amount, CreditCardInformation creditCardInfo)
        {
            BillingHistory.Add(
                new MonthlyBill(billingPeriod, TeanantBillingConstants.PaymentPlans.MonthlySubscription, amount, creditCardInfo)
            );
        }
    }
}

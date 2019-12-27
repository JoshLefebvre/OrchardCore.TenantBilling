using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LefeWareLearning.TenantBilling.Models
{
    public class TenantBillingHistory
    {
        public string TenantId { get; set; }

        public List<MonthlyBill> MonthlyBills { get; set; }

        public TenantBillingHistory(string tenantId)
        {
            TenantId = TenantId;
            MonthlyBills = new List<MonthlyBill>();
        }

        public void AddMonthlyBill(DateTime billingPeriod, decimal amount, PaymentMethods paymentMethod)
        {
            MonthlyBills.Add(
                new MonthlyBill(billingPeriod, TeanantBillingConstants.PaymentPlans.MonthlySubscription, amount, paymentMethod)
            );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LefeWareLearning.TenantBilling.Models;
using LefeWareLearning.Tenants.Repositories;

namespace LefeWareLearning.TenantBilling.EventHandlers
{
    public class MonthlyPaymentSuccessEventHandler : IPaymentSuccessEventHandler
    {
        private readonly ITenantBillingHistoryRepository _tenantBillingRepo;
        public MonthlyPaymentSuccessEventHandler(ITenantBillingHistoryRepository tenantBillingRepo)
        {
            _tenantBillingRepo = tenantBillingRepo;
        }

        public async Task PaymentSuccess(string tenantId, DateTime paymentMonth, decimal amount)
        {
            //Check if billing history exists
            var tenantBillingHistory = await _tenantBillingRepo.GetTenantBillingHistoryById(tenantId);
            if(tenantBillingHistory==null)
            {
               tenantBillingHistory = new Models.TenantBillingDetails(tenantId);
            }

            tenantBillingHistory.AddMonthlyBill(paymentMonth, amount, PaymentMethods.Card);

            await _tenantBillingRepo.CreateAsync(tenantBillingHistory);
        }
    }
}

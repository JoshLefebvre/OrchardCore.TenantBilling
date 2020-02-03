using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LefeWareLearning.TenantBilling.Models;
using LefeWareLearning.Tenants.Repositories;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Environment.Shell;
using OrchardCore.TenantBilling.Models;

namespace LefeWareLearning.TenantBilling.EventHandlers
{
    public class MonthlyPaymentSuccessEventHandler : IPaymentSuccessEventHandler
    {
        private readonly IShellSettingsManager _shellSettingsManager;
        private readonly ITenantBillingHistoryRepository _tenantBillingRepo;
        private readonly IShellHost _shellHost;

        public MonthlyPaymentSuccessEventHandler(IShellSettingsManager shellSettingsManager, IShellHost shellHost, ITenantBillingHistoryRepository tenantBillingRepo)
        {
            _shellSettingsManager = shellSettingsManager;
            _shellHost = shellHost;
            _tenantBillingRepo = tenantBillingRepo;
        }

        public async Task PaymentSuccess(string tenantId, string tenantName, BillingPeriod billingPeriod, decimal amount, PaymentMethod paymentMethod)
        {

            //TODO: Should billing info be saved in default tenant only, in the tenant's db, or both ?
                        
            // Retrieve settings for speficified tenant.
            var settingsList = _shellSettingsManager.LoadSettings();
            if (settingsList.Any())
            {
                var settings = settingsList.SingleOrDefault(s => string.Equals(s.Name, tenantName, StringComparison.OrdinalIgnoreCase));
                var shellScope = await _shellHost.GetScopeAsync(settings);
                await shellScope.UsingAsync(async scope =>
                {
                    //Check if billing history exists
                    var tenantBillingRepo = scope.ServiceProvider.GetServices<ITenantBillingHistoryRepository>().FirstOrDefault();
                    var tenantBillingHistory = await tenantBillingRepo.GetTenantBillingDetailsByNameAsync(tenantName);
                    if(tenantBillingHistory==null)
                    {
                        tenantBillingHistory = new TenantBillingDetails(tenantId, tenantName);
                    }
                    
                    if(tenantBillingHistory.IsNewPaymentMethod(paymentMethod))
                    {
                        tenantBillingHistory.AddNewPaymentMethod(paymentMethod);
                    }

                    tenantBillingHistory.AddMonthlyBill(billingPeriod, amount, paymentMethod.CreditCardInfo);



                    await tenantBillingRepo.CreateAsync(tenantBillingHistory);
                });
            }
        }
    }
}

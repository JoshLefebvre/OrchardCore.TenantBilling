using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.TenantBilling.Models;
using OrchardCore.Tenants.Repositories;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Environment.Shell;

namespace OrchardCore.TenantBilling.EventHandlers
{
    public class MonthlyPaymentSuccessEventHandler : ISubscriptionPaymentSuccessEventHandler
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

        public async Task SubscriptionPaymentSuccess(string tenantId, string tenantName, BillingPeriod billingPeriod, decimal amount, PaymentMethod paymentMethod, string planName)
        {

            //TODO: Should billing info be saved in default tenant only, in the tenant's db, or both ?
                        
            // Retrieve settings for speficified tenant.
            var settingsList = await _shellSettingsManager.LoadSettingsAsync();
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
                        tenantBillingHistory = new TenantBillingDetails(tenantId, tenantName, planName);
                    }
                    
                    if(tenantBillingHistory.IsNewPaymentMethod(paymentMethod))
                    {
                        tenantBillingHistory.AddNewPaymentMethod(paymentMethod);
                    }

                    tenantBillingHistory.AddMonthlyBill(billingPeriod, PaymentStatus.Success, amount, paymentMethod.CreditCardInfo);



                    await tenantBillingRepo.CreateAsync(tenantBillingHistory);
                });
            }
        }
    }
}

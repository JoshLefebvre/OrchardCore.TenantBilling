using System;
using System.Linq;
using System.Threading.Tasks;
using OrchardCore.TenantBilling.Models;
using OrchardCore.Tenants.Repositories;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Environment.Shell;

namespace OrchardCore.TenantBilling.EventHandlers
{
    public class MonthlyPaymentFailedEventHandler: IPaymentFailedEventHandler
    {
        private readonly IShellSettingsManager _shellSettingsManager;
        private readonly ITenantBillingHistoryRepository _tenantBillingRepo;
        private readonly IShellHost _shellHost;

        public MonthlyPaymentFailedEventHandler(IShellSettingsManager shellSettingsManager, IShellHost shellHost, ITenantBillingHistoryRepository tenantBillingRepo)
        {
            _shellSettingsManager = shellSettingsManager;
            _shellHost = shellHost;
            _tenantBillingRepo = tenantBillingRepo;
        }

        public async Task PaymentFailed(string tenantId, string tenantName, BillingPeriod billingPeriod, PaymentMethod paymentMethod, string planName)
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
                        //TODO: Create custom exception
                        throw new Exception();
                        //tenantBillingHistory = new TenantBillingDetails(tenantId, tenantName);
                    }
                    tenantBillingHistory.AddMonthlyBill(billingPeriod, PaymentStatus.Failed, 0, paymentMethod.CreditCardInfo);


                    await tenantBillingRepo.CreateAsync(tenantBillingHistory);
                });
            }
        }
    }
}

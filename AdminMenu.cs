using System;
using System.Threading.Tasks;
using LefeWareLearning.TenantBilling;
using LefeWareLearning.TenantPayment;
using Microsoft.Extensions.Localization;
using OrchardCore.Environment.Shell.Descriptor.Models;
using OrchardCore.Modules;
using OrchardCore.Navigation;

namespace LefeWareLearning.ManagePayment
{
    [Feature(TeanantBillingConstants.Features.TenantBilling)]
    public class AdminMenuTenantBilling : INavigationProvider
    {
        private readonly ShellDescriptor _shellDescriptor;

        public AdminMenuTenantBilling(IStringLocalizer<AdminMenuTenantBilling> localizer, ShellDescriptor shellDescriptor)
        {
            T = localizer;
            _shellDescriptor = shellDescriptor;
        }

        public IStringLocalizer T { get; set; }

        public Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            if (String.Equals(name, "admin", StringComparison.OrdinalIgnoreCase))
            {
                builder.Add(T["Payment"], "15", settings => settings
                        .AddClass("payment").Id("payment")
                        .Add(T["Add or Update Payment Info"], "1", client => client
                            .Action("AddOrUpdatePaymentInfo", "Admin", new { area = "LefeWareLearning.TenantBilling" })
                            .Permission(Permissions.ManageTenantBilling)
                            .LocalNav())
                        .Add(T["Billing History"], "2", client => client
                            .Action("BillingHistory", "Admin", new { area = "LefeWareLearning.TenantBilling" })
                            .Permission(Permissions.ManageTenantBilling)
                            .LocalNav())
                    );

            }
            return Task.CompletedTask;
        }
    }
}
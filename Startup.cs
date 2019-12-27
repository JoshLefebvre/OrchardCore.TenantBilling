using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;
using OrchardCore.Navigation;
using OrchardCore.Security.Permissions;
using OrchardCore.Settings;
using LefeWareLearning.TenantBilling;
using LefeWareLearning.ManagePayment;
using LefeWareLearning.Tenants.Repositories;
using LefeWareLearning.TenantBilling.Repositories;

namespace LefeWareLearning.TenantPayment
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPermissionProvider, Permissions>();
        }
    }

    [Feature(TeanantBillingConstants.Features.TenantBilling)]
    public class TenantPaymentStartup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<INavigationProvider, AdminMenuTenantBilling>();
            services.AddTransient<ITenantBillingHistoryRepository, TenantBillingHistoryRepository>();
        }

        public override void Configure(IApplicationBuilder app, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {

        }
    }
}

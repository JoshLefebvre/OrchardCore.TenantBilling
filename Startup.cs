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
using OrchardCore.TenantBilling;
using OrchardCore.Tenants.Repositories;
using OrchardCore.TenantBilling.Repositories;
using OrchardCore.TenantBilling.EventHandlers;
using OrchardCore.Data.Migration;
using YesSql.Indexes;
using OrchardCore.TenantBilling.Indexes;

namespace OrchardCore.TenantPayment
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPermissionProvider, OrchardCore.TenantBilling.Permissions>();
        }
    }

    [Feature(TeanantBillingConstants.Features.TenantBilling)]
    public class TenantPaymentStartup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<INavigationProvider, AdminMenuTenantBilling>();
            
            //Data
            services.AddScoped<IDataMigration, Migrations>();
            services.AddSingleton<IIndexProvider, TenantBillingDetailsIndexProvider>();
            services.AddTransient<ITenantBillingHistoryRepository, TenantBillingHistoryRepository>();
            
            //Event Handlers
            services.AddScoped<ISubscriptionPaymentSuccessEventHandler, MonthlyPaymentSuccessEventHandler>();
            services.AddScoped<ISubscriptionPaymentFailedEventHandler, MonthlyPaymentFailedEventHandler>();
        }

        public override void Configure(IApplicationBuilder app, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {

        }
    }
}

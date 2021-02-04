using System.Threading.Tasks;
using OrchardCore.TenantBilling.Models;

namespace OrchardCore.TenantBilling.EventHandlers
{
    public interface ISubscriptionPaymentFailedEventHandler
    {
        Task SubscriptionPaymentFailed(string tenantId, string tenantName, BillingPeriod billingPeriod, PaymentMethod paymentMethod, string planName);
    }
}

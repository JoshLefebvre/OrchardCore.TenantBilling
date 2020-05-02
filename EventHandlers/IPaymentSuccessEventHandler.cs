using System.Threading.Tasks;
using OrchardCore.TenantBilling.Models;

namespace OrchardCore.TenantBilling
{
    public interface IPaymentSuccessEventHandler
    {
        Task PaymentSuccess(string tenantId, string tenantName, BillingPeriod billingPeriod, decimal amount, PaymentMethod paymentMethod, string planName);
    }
}

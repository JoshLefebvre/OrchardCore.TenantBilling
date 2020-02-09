using System.Threading.Tasks;
using LefeWareLearning.TenantBilling.Models;
using OrchardCore.TenantBilling.Models;

namespace LefeWareLearning.TenantBilling
{
    public interface IPaymentSuccessEventHandler
    {
        Task PaymentSuccess(string tenantId, string tenantName, BillingPeriod billingPeriod, decimal amount, PaymentMethod paymentMethod, string planName);
    }
}

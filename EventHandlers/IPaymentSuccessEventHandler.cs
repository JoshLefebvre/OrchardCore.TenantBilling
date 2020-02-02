using System.Threading.Tasks;
using OrchardCore.TenantBilling.Models;

namespace LefeWareLearning.TenantBilling
{
    public interface IPaymentSuccessEventHandler
    {
        Task PaymentSuccess(string tenantId, string tenantName, BillingPeriod billingPeriod, decimal amount);
    }
}

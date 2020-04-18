using System.Threading.Tasks;
using OrchardCore.TenantBilling.Models;

namespace OrchardCore.Tenants.Repositories
{
    public interface ITenantBillingHistoryRepository
    {
        Task CreateAsync(TenantBillingDetails tenantBillingDetails);
        Task DeleteAsync(string tenantId);
        Task<TenantBillingDetails> GetTenantBillingDetailsByNameAsync(string name);
    }
}

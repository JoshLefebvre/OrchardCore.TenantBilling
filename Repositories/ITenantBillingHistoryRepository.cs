using System.Threading.Tasks;
using LefeWareLearning.TenantBilling.Models;

namespace LefeWareLearning.Tenants.Repositories
{
    public interface ITenantBillingHistoryRepository
    {
        Task CreateAsync(TenantBillingDetails tenantBillingDetails);
        Task DeleteAsync(string tenantId);
        Task<TenantBillingDetails> GetTenantBillingDetailsByNameAsync(string name);
    }
}
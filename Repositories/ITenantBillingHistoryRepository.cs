using System.Threading.Tasks;
using LefeWareLearning.TenantBilling.Models;

namespace LefeWareLearning.Tenants.Repositories
{
    public interface ITenantBillingHistoryRepository
    {
        Task CreateAsync(TenantBilling.Models.TenantBillingDetails history);
        Task DeleteAsync(string tenantId);
        Task<TenantBilling.Models.TenantBillingDetails> GetTenantBillingHistoryById(string id);
    }
}
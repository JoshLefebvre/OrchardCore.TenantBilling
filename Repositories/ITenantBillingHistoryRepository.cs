using System.Threading.Tasks;
using LefeWareLearning.TenantBilling.Models;

namespace LefeWareLearning.Tenants.Repositories
{
    public interface ITenantBillingHistoryRepository
    {
        Task CreateAsync(TenantBillingHistory history);
        Task DeleteAsync(string tenantId);
        Task<TenantBillingHistory> GetTenantBillingHistoryById(string id);
    }
}
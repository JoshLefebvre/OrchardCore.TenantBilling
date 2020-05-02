using System;
using System.Threading.Tasks;
using OrchardCore.TenantBilling.Indexes;
using OrchardCore.TenantBilling.Models;
using OrchardCore.Tenants.Repositories;
using Microsoft.Extensions.Caching.Memory;
using OrchardCore.Environment.Cache;
using YesSql;

namespace OrchardCore.TenantBilling.Repositories
{
    public class TenantBillingHistoryRepository : ITenantBillingHistoryRepository
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ISession _session;

        private const string TenantBillingHistoryCacheKey = "TenantBillingHistory";

        public TenantBillingHistoryRepository(ISession session, IMemoryCache memoryCache)
        {
            _session = session;
            _memoryCache = memoryCache;
        }

        public async Task CreateAsync(TenantBillingDetails tenantBillingDetails)
        {
            var cacheKey = $"{TenantBillingHistoryCacheKey}-{tenantBillingDetails.TenantName}";
            _session.Save(tenantBillingDetails);
            _memoryCache.Set(cacheKey, tenantBillingDetails);
        }

        public async Task<TenantBillingDetails> GetTenantBillingDetailsByNameAsync(string tenantName)
        {
            TenantBillingDetails history;
            var cacheKey = $"{TenantBillingHistoryCacheKey}-{tenantName}";

            if (!_memoryCache.TryGetValue(cacheKey, out history))
            {
                history= await _session.Query<TenantBillingDetails, TenantBillingDetailsIndex>(t => t.TenantName == tenantName).FirstOrDefaultAsync();
                _memoryCache.Set(cacheKey, history);
            }

            return history;
        }


        public async Task DeleteAsync(string tenantId)
        {
            throw new NotImplementedException();
        }
    }
}

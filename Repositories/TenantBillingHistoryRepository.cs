using System;
using System.Threading.Tasks;
using LefeWareLearning.TenantBilling.Indexes;
using LefeWareLearning.TenantBilling.Models;
using LefeWareLearning.Tenants.Repositories;
using Microsoft.Extensions.Caching.Memory;
using OrchardCore.Environment.Cache;
using YesSql;

namespace LefeWareLearning.TenantBilling.Repositories
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

        public async Task CreateAsync(TenantBillingDetails history)
        {
            var cacheKey = $"{TenantBillingHistoryCacheKey}-{history.TenantId}";
            _session.Save(history);
            _memoryCache.Set(cacheKey, history);
        }

        public async Task<TenantBillingDetails> GetTenantBillingHistoryById(string id)
        {
            TenantBillingDetails history;
            var cacheKey = $"{TenantBillingHistoryCacheKey}-{id}";

            if (!_memoryCache.TryGetValue(cacheKey, out history))
            {
                history= await _session.Query<TenantBillingDetails, TenantBillingDetailsIndex>(t => t.TenantId == id).FirstOrDefaultAsync();
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

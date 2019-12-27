using System;
using LefeWareLearning.TenantBilling.Models;
using YesSql.Indexes;

namespace LefeWareLearning.TenantBilling.Indexes
{
    public class TenantBillingHistoryIndex : MapIndex
    {
        public string TenantId{ get; set; }
    }

    public class TenantIndexProvider : IndexProvider<TenantBillingHistory>
    {
        public override void Describe(DescribeContext<TenantBillingHistory> context)
        {
            context.For<TenantBillingHistoryIndex>()
                .Map(tenantBillingHistory =>
                {
                    return new TenantBillingHistoryIndex
                    {
                        TenantId = tenantBillingHistory.TenantId,
                    };
                });
        }
    }

}

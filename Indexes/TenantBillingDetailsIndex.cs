using System;
using LefeWareLearning.TenantBilling.Models;
using YesSql.Indexes;

namespace LefeWareLearning.TenantBilling.Indexes
{
    public class TenantBillingDetailsIndex : MapIndex
    {
        public string TenantId{ get; set; }
    }

    public class TenantBillingDetailsIndexProvider : IndexProvider<Models.TenantBillingDetails>
    {
        public override void Describe(DescribeContext<Models.TenantBillingDetails> context)
        {
            context.For<TenantBillingDetailsIndex>()
                .Map(tenantBillingHistory =>
                {
                    return new TenantBillingDetailsIndex
                    {
                        TenantId = tenantBillingHistory.TenantId,
                    };
                });
        }
    }

}

using OrchardCore.TenantBilling.Indexes;
using OrchardCore.Data.Migration;
using YesSql.Sql;

namespace OrchardCore.TenantBilling
{
    public class Migrations : DataMigration
    {
        public int Create()
        {
            SchemaBuilder.CreateMapIndexTable<TenantBillingDetailsIndex>(table => table
                .Column<string>("TenantId")
                .Column<string>("TenantName")
            );

            return 1;
        }
    }
}

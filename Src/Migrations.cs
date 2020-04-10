using LefeWareLearning.TenantBilling.Indexes;
using OrchardCore.Data.Migration;

namespace LefeWareLearning.TenantBilling
{
    public class Migrations : DataMigration
    {
        public int Create()
        {
            SchemaBuilder.CreateMapIndexTable(nameof(TenantBillingDetailsIndex), table => table
                .Column<string>("TenantId")
                .Column<string>("TenantName")
            );

            return 1;
        }
    }
}
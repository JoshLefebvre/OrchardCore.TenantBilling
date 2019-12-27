using LefeWareLearning.TenantBilling.Indexes;
using OrchardCore.Data.Migration;

namespace LefeWareLearning.TenantBilling
{
    public class Migrations : DataMigration
    {
        public int Create()
        {
            SchemaBuilder.CreateMapIndexTable(nameof(TenantBillingHistoryIndex), table => table
                .Column<string>("TenantId")
            );

            return 1;
        }
    }
}
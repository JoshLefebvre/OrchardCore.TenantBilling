using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrchardCore.Security.Permissions;

namespace OrchardCore.TenantBilling
{
    public class Permissions : IPermissionProvider
    {
        public static readonly Permission ManageTenantBilling= new Permission(nameof(ManageTenantBilling), "Manage Tenant Billing");

        public Task<IEnumerable<Permission>> GetPermissionsAsync()
        {
            return Task.FromResult(new[] { ManageTenantBilling }.AsEnumerable());
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            yield return new PermissionStereotype
            {
                Name = "Administrator",
                Permissions = new[]
                {
                    ManageTenantBilling
                }
            };
        }
    }
}

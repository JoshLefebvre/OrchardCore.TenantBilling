using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "TenantBilling",
    Author = "LefeWareLearning",
    Website = "https://github.com/JoshLefebvre",
    Version = "1.0.0",
    Category = "Tenant Billing"
)]

[assembly: Feature(
    Id = "LefeWareLearning.TenantBilling",
    Name = "TenantBilling",
    Category = "LefeWare Learning Core",
    Description = "Allows users to view and update billing information",
    Dependencies = new[]
    {
        "OrchardCore.Tenants",
    }
)]

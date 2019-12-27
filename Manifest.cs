using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "TenantBilling",
    Author = "LefeWareLearning",
    Website = "https://orchardproject.net",
    Version = "1.0.0",
    Category = "LefeWare Learning"
)]

[assembly: Feature(
    Id = "LefeWareLearning.TenantBilling",
    Name = "TenantBilling",
    Category = "LefeWare Learning Core",
    Description = "Allows users to view and update billing",
    Dependencies = new[]
    {
        "OrchardCore.Tenants",
    }
)]

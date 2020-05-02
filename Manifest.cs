using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "TenantBilling",
    Author = "LefeWareLearning",
    Website = "https://github.com/JoshLefebvre",
    Version = "1.0.0",
    Category = "Payment"
)]

[assembly: Feature(
    Id = "OrchardCore.TenantBilling",
    Name = "TenantBilling",
    Category = "Payment",
    Description = "Allows users to view and update billing information",
    Dependencies = new[]
    {
        "OrchardCore.Tenants",
    }
)]

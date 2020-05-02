# OrchardCore.TenantBilling
An Orchard Core module to keep track of multi tenant SaaS payments and billing.

- This module is not meant to actually process any payments, rather it is meant to be used in conjuction with other extension modules for actual payment:
    - Stripe: https://github.com/JoshLefebvre/OrchardCore.StripePayment   
- The goal of this module is to handle generic information related to a tenant's monthly billing cycle (subscription based)
- This module is still in early stages of development and is not ready for consumption.

## TODOs


## Setting up your dev environment
1. **Prerequisites:** Make sure you have an up-to-date clone of [the Orchard Core repository](https://github.com/OrchardCMS/OrchardCore) on the `dev` branch. Please consult [the Orchard Core documentation](https://orchardcore.readthedocs.io/en/latest/) and make sure you have a working Orchard before you proceed. You'll also, of course, need all of Orchard Core's prerequisites for development (.NET Core, a code editor, etc.). The following steps assume some basic understanding of Orchard Core.
2. Clone the module under `[your Orchard Core clone's root]/src/OrchardCore.Modules`.
3. Add the existing project to the solution under `src/OrchardCore.Modules` in the solution explorer if you're using Visual Studio.
4. Add a reference to the module from the `OrchardCore.Cms.Web` project.
5. Build, run.
6. From the admin, enable the module's only feature.
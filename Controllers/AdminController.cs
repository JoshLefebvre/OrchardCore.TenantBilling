using System.Linq;
using System.Threading.Tasks;
using LefeWareLearning.Tenants.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.Environment.Shell;

namespace LefeWareLearning.TenantBilling.Controllers
{
    public class AdminController : Controller
    {
        private readonly IShellFeaturesManager _shellFeaturesManager;
        private readonly ShellSettings _currentShellSettings;
        private readonly IAuthorizationService _authorizationService;
        private readonly ITenantBillingHistoryRepository _tenantBillingRepo;

        public AdminController(IShellFeaturesManager shellFeaturesManager, IAuthorizationService authorizationService, 
        ShellSettings currentShellSettings, ITenantBillingHistoryRepository tenantBillingRepo)
        {
            _authorizationService = authorizationService;
            _currentShellSettings = currentShellSettings;
            _shellFeaturesManager = shellFeaturesManager;
            _tenantBillingRepo = tenantBillingRepo;
        }

        [HttpGet]
        public async Task<IActionResult> AddOrUpdatePaymentInfo()
        {
            if (!await _authorizationService.AuthorizeAsync(User, Permissions.ManageTenantBilling))
            {
                return Unauthorized();
            }

            //Determine if there is an existing subscription
            bool hasSubscription = false;
            var tenantName = _currentShellSettings.Name;
            var billingDetails = await _tenantBillingRepo.GetTenantBillingDetailsByNameAsync(tenantName);
            if(billingDetails!=null)
            {
                hasSubscription = true;
            }
            

            //We need to ensure only 1 payment type can be enabled
            var paymentType = _shellFeaturesManager.GetEnabledFeaturesAsync().Result.Where(x=>x.Category == "LefeWare Learning Payment Types").FirstOrDefault();
            if(paymentType == null)
            {
                return BadRequest();
            }

            var area = paymentType.Id;

            return RedirectToAction("Index", "Admin", new { Area = area });
        }

        [HttpGet]
        public async Task<IActionResult> BillingHistory()
        {
            if (!await _authorizationService.AuthorizeAsync(User, Permissions.ManageTenantBilling))
            {
                return Unauthorized();
            }

            //Get Tenant Billing history
            var tenantName = _currentShellSettings.Name;
            var billingDetails = await _tenantBillingRepo.GetTenantBillingDetailsByNameAsync(tenantName);


            //TODO: Create viewmodel
            return View(billingDetails);
        }
    }
}

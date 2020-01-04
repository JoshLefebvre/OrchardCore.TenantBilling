using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.Environment.Shell;

namespace LefeWareLearning.TenantBilling.Controllers
{
    public class AdminController : Controller
    {
        private readonly IShellFeaturesManager _shellFeaturesManager;
        private readonly IAuthorizationService _authorizationService;
        public AdminController(IShellFeaturesManager shellFeaturesManager, IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            _shellFeaturesManager = shellFeaturesManager;
        }

        [HttpGet]
        public async Task<IActionResult> AddOrUpdatePaymentInfo()
        {
            if (!await _authorizationService.AuthorizeAsync(User, Permissions.ManageTenantBilling))
            {
                return Unauthorized();
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
            return View();
        }
    }
}

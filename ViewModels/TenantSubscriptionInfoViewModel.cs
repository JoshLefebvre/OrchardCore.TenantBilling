using System.Collections.Generic;
using LefeWareLearning.TenantBilling.Models;

namespace OrchardCore.TenantBilling.ViewModels
{
    public class TenantSubscriptionInfoViewModel
    {
        public bool HasSubscription { get; set; }

        public List<PaymentMethod> PaymentMethods { get; set; }
    }
}
using System.Collections.Generic;
using LefeWareLearning.TenantBilling.Models;

namespace OrchardCore.TenantBilling.ViewModels
{
    public class TenantSubscriptionInfoViewModel
    {
        public bool HasSubscription { get; set; }

        public string CurrentPlanDescription { get; set; }

        public PaymentMethod CurrentPaymentMethod { get; set; }

        public int DaysLeftInFreeSubscription { get; set; }
    }
}
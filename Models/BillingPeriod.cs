using System;

namespace OrchardCore.TenantBilling.Models
{
    public class BillingPeriod
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public BillingPeriod(DateTime start, DateTime end)
        {
            this.Start = start;
            this.End = end;

        }
    }
}
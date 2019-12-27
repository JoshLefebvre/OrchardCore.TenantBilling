using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LefeWareLearning.TenantBilling
{
    public interface IPaymentSuccessEventHandler
    {
        Task PaymentSuccess(string tenantId, DateTime paymentMonth, decimal amount);
    }
}

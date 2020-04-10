namespace LefeWareLearning.TenantBilling.Models
{
    public class PaymentMethod
    {
        public bool ActiveCard { get; private set; }
        public CreditCardInformation CreditCardInfo { get; private set; }

        public PaymentMethod(bool activeCard, CreditCardInformation creditCardInfo)
        {
            this.ActiveCard = activeCard;
            this.CreditCardInfo = creditCardInfo;
        }
    }
}
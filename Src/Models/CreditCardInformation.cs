using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LefeWareLearning.TenantBilling.Models
{
    public class CreditCardInformation
    {

        public CardType CardType { get; private set; }

        public int Last4Digits { get; private set; }

        public int ExpiryMonth { get; private set; }

        public int ExpiryYear { get; private set; }

        public CreditCardInformation(CardType cardType, int last4Digits, int expiryMonth, int expiryYear)
        {
            //Up for Grabs: Add validation
            CardType = cardType;
            Last4Digits = last4Digits;
            ExpiryMonth = expiryMonth;
            ExpiryYear = expiryYear;
        }
    }
}

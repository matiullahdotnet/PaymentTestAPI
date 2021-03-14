using System;

namespace Core.Common.DTOs.Team
{
    public class PaymentBaseDto
    {
        public string CreditCardNumber { get; set; }

        public string CardHolder { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string SecurityCode { get; set; }

        public decimal Amount { get; set; }

        public string PaymentStatus { get; set; }
    }
}

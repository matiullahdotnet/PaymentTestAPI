using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Payment.Models.Payment
{
    public class PaymentBaseViewModel
    {
        [Required]
        public string CreditCardNumber { get; set; }

        [Required]
        public string CardHolder { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public string SecurityCode { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string PaymentStatus { get; set; }
    }
}

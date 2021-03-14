using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.DataAccessLayer.Entities.Core;

namespace Data.DataAccessLayer.Entities
{
    public class Payment : IEntity
    {
        [Key]
        public int PaymentId { get; set; }

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

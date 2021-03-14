using AutoMapper;
using Business.Engine.Interfaces;
using Core.Common.DTOs.Team;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Controllers {

    [ApiController]
    public class PaymentController : ControllerBase {
        private readonly IMapper _mapper;
        private readonly IPaymentEngine _paymentEngine;
        private readonly ICheapPaymentGateway _cheapPaymentGateway;
        private readonly IExpensivePaymentGateway _expensePaymentGateway;
        private readonly IPremiumPaymentGateway _premiumPaymentGateway;

       public PaymentController(IPaymentEngine paymentEngine, IMapper mapper, ICheapPaymentGateway cheapPaymentGateway,
            IExpensivePaymentGateway expensivePaymentGateway, IPremiumPaymentGateway premiumPaymentGateway) {
            _paymentEngine = paymentEngine ?? throw new ArgumentNullException(nameof(paymentEngine));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _cheapPaymentGateway = cheapPaymentGateway ?? throw new ArgumentNullException(nameof(cheapPaymentGateway));
            _expensePaymentGateway = expensivePaymentGateway ?? throw new ArgumentNullException(nameof(expensivePaymentGateway));
            _premiumPaymentGateway = premiumPaymentGateway ?? throw new ArgumentNullException(nameof(premiumPaymentGateway));
        }

        [HttpPost("Payment/ProcessPayment")]
        public IActionResult ProcessPayment(PaymentViewModel payment) {
            bool _paymentStauts = false;
            try {

                if (payment.Amount <= 20) {
                    _paymentStauts = _cheapPaymentGateway.Pay(_mapper.Map<PaymentViewModel, PaymentDto>(payment));
                } else if (payment.Amount > 20 && payment.Amount < 500) {
                    _paymentStauts = _expensePaymentGateway.Pay(_mapper.Map<PaymentViewModel, PaymentDto>(payment));
                } else if (payment.Amount >= 500) {
                    _paymentStauts = _premiumPaymentGateway.Pay(_mapper.Map<PaymentViewModel, PaymentDto>(payment));
                }

                var model = _mapper.Map<PaymentViewModel, PaymentDto>(payment);
                model.PaymentStatus = _paymentStauts == true ? "paid" : "unpaid";
                _paymentEngine.AddPayment(model);

                if (_paymentStauts) {
                    return Ok();
                } else  {
                    return BadRequest();
                } 

            } catch (Exception) {
                return StatusCode(500);
            }          

        }
    }
}

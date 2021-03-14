using Business.Engine.Interfaces;
using Core.ApplicationCore.UnitOfWork;
using Core.Common.DTOs.Team;
using Data.DataAccessLayer.Context;
using Data.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Engine.Engines
{
    public class PaymentEngine : IPaymentEngine
    {
        private readonly IUnitOfWork<PaymentAppContext> _unitOfWork;

        public PaymentEngine(IUnitOfWork<PaymentAppContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddPayment(PaymentDto model)
        {
            Payment team = await _unitOfWork.GetRepository<Payment>().AddAsync(new Payment {
                Amount = model.Amount,
                CardHolder = model.CardHolder,
                CreditCardNumber = model.CreditCardNumber,
                ExpirationDate = model.ExpirationDate,
                PaymentStatus = model.PaymentStatus,
                SecurityCode = model.SecurityCode
            });

            return team != null && team.PaymentId != 0;
        }

        public async Task<bool> UpdatePayment(PaymentDto model)
        {
            Payment team = await _unitOfWork.GetRepository<Payment>().UpdateAsync(new Payment {
                PaymentId = model.Id,
                Amount = model.Amount,
                CardHolder = model.CardHolder,
                CreditCardNumber = model.CreditCardNumber,
                ExpirationDate = model.ExpirationDate,
                PaymentStatus = model.PaymentStatus,
                SecurityCode = model.SecurityCode
            });

            return team != null;
        }
    }
}

using AutoMapper;
using Core.Common.DTOs.Team;
using Payment.Models.Payment;

namespace Payment.Profiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentDto, PaymentViewModel>();
            CreateMap<PaymentViewModel, PaymentDto>();
        }
    }
}

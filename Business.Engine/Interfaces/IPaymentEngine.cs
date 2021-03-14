using Core.Common.DTOs.Team;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Engine.Interfaces
{
    public interface IPaymentEngine
    {
        Task<bool> AddPayment(PaymentDto model);

        Task<bool> UpdatePayment(PaymentDto model);
    }
}

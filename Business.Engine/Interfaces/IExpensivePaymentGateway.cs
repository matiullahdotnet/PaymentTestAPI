using Core.Common.DTOs.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Engine.Interfaces {
    public interface IExpensivePaymentGateway {
        bool Connect();

        bool Pay(PaymentDto payment);
    }
}

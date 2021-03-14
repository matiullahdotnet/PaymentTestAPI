using Business.Engine.Interfaces;
using Core.Common.DTOs.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Engine.Engines {
   public  class ExpensivePaymentGateway: IExpensivePaymentGateway {
        public bool Connect() {
            return true;
        }

        public bool Pay(PaymentDto payment) {
            if (this.Connect() == true) {
                return true;
            } else {
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDrivenPaymentFlow.Domain
{
    public interface IPaymentsRepository
    {
        void Add(Payment payment);
    }
}

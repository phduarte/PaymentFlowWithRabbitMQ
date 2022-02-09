using EventDrivenPaymentFlow.Domain;
using System.Collections.Generic;

namespace EventDrivenPaymentFlow.Data
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private IList<Payment> _payments = new List<Payment>();

        public void Add(Payment payment)
        {
            _payments.Add(payment);
        }
    }
}

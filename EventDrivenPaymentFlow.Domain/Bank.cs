using System;

namespace EventDrivenPaymentFlow.Domain
{
    public class Bank : Entity<Guid>
    {
        public string Number { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Number} - {Name}";
        }
    }
}
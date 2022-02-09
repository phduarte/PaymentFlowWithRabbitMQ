using System;

namespace EventDrivenPaymentFlow.Domain
{
    public class BankAccount:Entity<Guid>
    {
        public string Number { get; set; }
        public int Branch { get; set; }
        public AccountType AccountType { get; set; }
        public Bank Bank { get; set; }
        public Person Client { get; set; }

        public override string ToString()
        {
            return $"{Number} - {Branch}";
        }
    }
}
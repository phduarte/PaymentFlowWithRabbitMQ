using System;

namespace EventDrivenPaymentFlow.Domain
{
    public class Payment : Entity<Guid>
    {
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public string DigitalizableLine { get; set; }
        public BankAccount BankAccount { get; set; }
        public Bank Bank { get; set; }
        public Person Beneficiary { get; set; }
        public Money Value { get; set; }

        public override string ToString()
        {
            return $"{Date} - {DigitalizableLine}";
        }
    }
}

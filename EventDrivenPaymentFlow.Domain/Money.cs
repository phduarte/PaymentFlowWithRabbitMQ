namespace EventDrivenPaymentFlow.Domain
{
    public class Money
    {
        public string Currency { get; set; }
        public decimal Value { get; set; }

        public override string ToString()
        {
            return $"{Currency} {Value:N2}";
        }
    }
}
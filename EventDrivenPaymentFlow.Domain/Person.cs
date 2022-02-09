namespace EventDrivenPaymentFlow.Domain
{
    public class Person
    {
        public string DocumentNumber { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
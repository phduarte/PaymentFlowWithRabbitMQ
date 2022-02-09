namespace EventDrivenPaymentFlow.Domain
{
    public interface IBanksRepository
    {
        Bank GetByNumber(string number);
    }
}

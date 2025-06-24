namespace Implementation.Service;

public interface IBankingService
{
    decimal GetBalance(string accountNumber);

    void MakePayment(string accountNumber, decimal payment);
}

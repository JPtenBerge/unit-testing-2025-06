using System.Collections.Generic;
using Implementation.Service;

namespace Implementation.UnitTest;

public class FakeBankingService : IBankingService
{

    public Dictionary<string, decimal> Balances { get; set; } = new ();
    public List<(string, decimal)> Payments { get; set; } = new();

    public decimal GetBalance(string accountNumber)
    {
        return Balances[accountNumber];
    }

    public void MakePayment(string accountNumber, decimal payment)
    {
        Payments.Add((accountNumber, payment));
    }
}
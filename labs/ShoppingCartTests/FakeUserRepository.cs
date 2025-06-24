using System.Collections.Generic;
using Implementation.Repository;

namespace Implementation.UnitTest;

public class FakeUserRepository : IUserRepository
{
    public Dictionary<string, User> UsersByUsername { get; set; } = new();
    public List<(string, decimal)> PaymentHistory { get; set; } = new ();

    public void AddPaymentHistory(string username, decimal payment)
    {
        PaymentHistory.Add((username, payment));
    }

    public User GetUser(string username)
    {
        return UsersByUsername[username];
    }
}
namespace Implementation.Repository;

public interface IUserRepository
{
    User GetUser(string username);

    void AddPaymentHistory(string username, decimal payment);
}

using System.Collections.Generic;
using Implementation.Repository;
using Implementation.Service;

namespace Implementation;

public class ShoppingCart
{
    private readonly IUserRepository _userRepository;
    private readonly IBankingService _bankingService;

    /// <summary>
    /// List to keep track of the items in the cart.
    /// </summary>
    public Dictionary<Product, int> Orders { get; } = new Dictionary<Product, int>();
    public ShoppingCart(string username, IUserRepository userRepository, IBankingService bankingService)
    {
        Orders = new Dictionary<Product, int>();
        Owner = username;
        _userRepository = userRepository;
        _bankingService = bankingService;
    }

    /// <summary>
    /// The owner of this shopping cart.
    /// </summary>
    public string Owner { get; private set; }

    /// <summary>
    /// Add a new item to this cart.
    /// </summary>
    /// <param name="item">The item to be added.</param>
    /// <param name="amount">The amount for this item to be added.</param>
    /// <remarks>
    /// When the item is already in the list, only the amount should be increased and no new item added.
    /// </remarks>
    public void Add(Product item, int amount)
    {
        if (Orders.ContainsKey(item))
        {
            Orders[item] += amount;
        }
        else
        {
            Orders.Add(item, amount);
        }
    }

    public decimal Total
    {
        get
        {
            decimal total = 0;
            foreach (var product in Orders.Keys)
            {
                total += product.Price * Orders[product];
            }
            return total;
        }
    }

    public void CheckOut()
    {
        var user = _userRepository.GetUser(Owner);
        var balance = _bankingService.GetBalance(user.AccountNumber);
        if (balance >= Total)
        {
            _bankingService.MakePayment(user.AccountNumber, Total);
            _userRepository.AddPaymentHistory(user.Name, Total);
        }
    }
}

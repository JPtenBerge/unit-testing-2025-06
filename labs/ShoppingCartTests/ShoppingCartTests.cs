namespace Implementation.UnitTest;

public class ShoppingCartTests
{
    private readonly Product _xbox = new Product("Xbox 360", 199.99m);
    private readonly Product _playstation = new Product("PlayStation3", 250);

    [Fact]
    public void Add_OneProduct_ShouldAddProductToCart()
    {
        // Arrange
        var sut = new ShoppingCart("Frank", null, null);

        // Act
        sut.Add(_xbox, 2);

        // Assert
        AssertProductIsInCart(sut, _xbox, 2);
    }

    [Fact]
    public void Add_TwiceSameProduct_ShouldAddToExistingAmount()
    {
        var sut = new ShoppingCart("Frank", null, null);
        sut.Add(_xbox, 2);
        sut.Add(_xbox, 3);
        AssertProductIsInCart(sut, _xbox, 5);
    }

    [Fact]
    public void Add_TwoDifferentProducts_ShouldAddBothToCart()
    {
        var sut = new ShoppingCart("Frank", null, null);
        sut.Add(_xbox, 1);
        sut.Add(_playstation, 2);
        AssertProductIsInCart(sut, _xbox, 1);
        AssertProductIsInCart(sut, _playstation, 2);
    }

    [Fact]
    public void Total_EmptyCart_ShouldBeZero()
    {
        var sut = new ShoppingCart("Frank", null, null);
        Assert.Equal(0, sut.Total);
    }

    [Fact]
    public void Total_TwoProductsWithDifferentAmount_ShouldCalculateCorrectTotal()
    {
        var sut = new ShoppingCart("Frank", null, null);
        sut.Add(_playstation, 2); //500
        sut.Add(_xbox, 1); //199.99
        Assert.Equal(699.99m, sut.Total);
    }

    [Fact]
    public void Checkout_SufficientBalance_AddsToPaymentHistory()
    {
        var userRepository = new FakeUserRepository();
        var bankingService = new FakeBankingService();
        var frank = new User("Frank", new DateTime(2010, 1, 1), "1234");
        userRepository.UsersByUsername["frank"] = frank;
        bankingService.Balances["1234"] = 1000;
        var sut = new ShoppingCart("frank", userRepository, bankingService);
        sut.Add(_xbox, 1);
        sut.CheckOut();
        Assert.Single(userRepository.PaymentHistory, ("Frank", 199.99m));
    }


    [Fact]
    public void Checkout_InsufficientBalance_DoesNotAddToPaymentHistory()
    {
        var userRepository = new FakeUserRepository();
        var bankingService = new FakeBankingService();
        var frank = new User("Frank", new DateTime(2010, 1, 1), "1234");
        userRepository.UsersByUsername["frank"] = frank;
        bankingService.Balances["1234"] = 199.98m;
        var sut = new ShoppingCart("frank", userRepository, bankingService);
        sut.Add(_xbox, 1);
        sut.CheckOut();
        Assert.Empty(userRepository.PaymentHistory);
    }

    [Fact]
    public void Checkout_InsufficientBalance_DoesNotDoPayment()
    {
        var userRepository = new FakeUserRepository();
        var bankingService = new FakeBankingService();
        var frank = new User("Frank", new DateTime(2010, 1, 1), "1234");
        userRepository.UsersByUsername["frank"] = frank;
        bankingService.Balances["1234"] = 199.98m;
        var sut = new ShoppingCart("frank", userRepository, bankingService);
        sut.Add(_xbox, 1);
        sut.CheckOut();
        Assert.Empty(bankingService.Payments);
    }

    private void AssertProductIsInCart(ShoppingCart sut, Product expectedItem, int expectedAmount)
    {
        Assert.True(sut.Orders.ContainsKey(expectedItem));
        Assert.Equal(expectedAmount, sut.Orders[expectedItem]);
    }
}
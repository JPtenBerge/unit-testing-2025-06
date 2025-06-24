namespace Implementation;

public struct Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string name, decimal price)
        : this()
    {
        Name = name;
        Price = price;
    }
}
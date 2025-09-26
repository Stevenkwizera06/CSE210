namespace OnlineOrdering;

public class Product
{
    private readonly string _name;
    private readonly string _productId;
    private readonly decimal _pricePerUnit;
    private readonly int _quantity;

    public Product(string name, string productId, decimal pricePerUnit, int quantity)
    {
        _name = name;
        _productId = productId;
        _pricePerUnit = pricePerUnit;
        _quantity = quantity;
    }

    public string Name => _name;
    public string ProductId => _productId;
    public decimal PricePerUnit => _pricePerUnit;
    public int Quantity => _quantity;

    public decimal GetTotalCost()
    {
        return _pricePerUnit * _quantity;
    }
}



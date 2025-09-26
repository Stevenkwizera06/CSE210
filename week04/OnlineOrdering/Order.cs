using System.Text;

namespace OnlineOrdering;

public class Order
{
    private readonly List<Product> _products = new();
    private readonly Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal CalculateTotal()
    {
        decimal productsTotal = 0m;
        foreach (var product in _products)
        {
            productsTotal += product.GetTotalCost();
        }

        decimal shipping = _customer.IsInUSA() ? 5m : 35m;
        return productsTotal + shipping;
    }

    public string GetPackingLabel()
    {
        var sb = new StringBuilder();
        sb.AppendLine("PACKING LABEL");
        foreach (var product in _products)
        {
            sb.AppendLine($"- {product.Name} (ID: {product.ProductId})");
        }
        return sb.ToString();
    }

    public string GetShippingLabel()
    {
        var sb = new StringBuilder();
        sb.AppendLine("SHIPPING LABEL");
        sb.AppendLine(_customer.Name);
        sb.AppendLine(_customer.Address.FormatMultiline());
        return sb.ToString();
    }
}



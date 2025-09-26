namespace OnlineOrdering;

public class Customer
{
    private readonly string _name;
    private readonly Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string Name => _name;
    public Address Address => _address;

    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }
}



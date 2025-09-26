namespace OnlineOrdering;

public class Address
{
    private readonly string _street;
    private readonly string _city;
    private readonly string _stateOrProvince;
    private readonly string _country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        _street = street;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    public bool IsInUSA()
    {
        return string.Equals(_country, "USA", StringComparison.OrdinalIgnoreCase) ||
               string.Equals(_country, "United States", StringComparison.OrdinalIgnoreCase) ||
               string.Equals(_country, "United States of America", StringComparison.OrdinalIgnoreCase);
    }

    public string FormatMultiline()
    {
        return $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
    }
}



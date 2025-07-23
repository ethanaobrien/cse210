
public class Address
{
    private string _streetAddress;
    private string _state;
    private string _country;

    public Address(string address, string state, string country)
    {
        _streetAddress = address;
        _state = state;
        _country = country;
    }
    
    public bool IsInUsa()
    {
        return _country == "USA";
    }

    public string GetAddress()
    {
        var rv = $"{_streetAddress}\n" +
            $"{_state}\n" +
            $"{_country}";
        return rv;
    }
}

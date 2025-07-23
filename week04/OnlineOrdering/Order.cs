
public class Order
{
    private Customer _customer;
    private List<Product> _cart;

    public Order(Customer customer)
    {
        _cart = [];
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _cart.Add(product);
    }
    
    public double GetTotalPrice()
    {
        var cost = _cart.Sum(product => product.GetTotalPrice());
        var shippingPrice = _customer.IsInUsa() ? 5 : 35;
        return cost + shippingPrice;
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()}\n" +
               $"{_customer.GetAddress()}";
    }

    public string GetPackingLabel()
    {
        var label = _cart.Aggregate("", (current, product) => current + (product.GetProductLabel() + "\n"));
        return label;
    }
}

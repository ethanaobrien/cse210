
public class Product
{
    private string _name;
    private int _productId;
    private int _quantity;
    private double _price;

    public Product(string name, int quantity)
    {
        _name = name;
        _quantity = quantity;
        
        // I believe this should be static????
        _productId = name switch
        {
            "Beans" => 1,
            "Cake" => 2,
            "Ice Cream" => 3,
            "Oranges" => 4,
            "Apples" => 5,
            "Chocolate Milk" => 6,
            _ => throw new ArgumentException("Product name is not sold here")
        };
        
        _price = name switch
        {
            "Beans" => 0.75,
            "Cake" => 25,
            "Ice Cream" => 7,
            "Oranges" => 0.50,
            "Apples" => 0.60,
            "Chocolate Milk" => 6,
            _ => throw new ArgumentException("Product name is not sold here")
        };
    }

    public string GetProductLabel()
    {
        return $"{_productId}-{_name}";
    }

    public double GetTotalPrice()
    {
        return _price *  _quantity;
    }
}

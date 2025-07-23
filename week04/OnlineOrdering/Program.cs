using System;

class Program
{
    static void Main(string[] args)
    {
        var orders = new List<Order>();
        var address = new Address("1234 Not An Address Drive", "Utah", "USA");
        var customer = new Customer("Jane Doe", address);
        var order1 = new Order(customer);
        order1.AddProduct(new Product("Beans", 200));
        order1.AddProduct(new Product("Cake", 1));
        order1.AddProduct(new Product("Oranges", 5));
        orders.Add(order1);
        
        var address2 = new Address("4321 Definitely An Address Dr.", "Utah", "USA");
        var customer2 = new Customer("Bob M", address2);
        var order2 = new Order(customer2);
        order2.AddProduct(new Product("Ice Cream", 1));
        order2.AddProduct(new Product("Chocolate Milk", 1));
        orders.Add(order2);
        
        foreach (var order in orders)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Packing label: ");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine();
            Console.WriteLine("Shipping Label: ");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();
            Console.WriteLine("Total Price: ");
            Console.WriteLine(order.GetTotalPrice());
        }
    }
}
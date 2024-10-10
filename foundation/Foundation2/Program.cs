using System;
using System.Collections.Generic;

// Class that represents a product
public class Product
{
    private string name;
    private string productId;
    private decimal price;
    private int quantity;

    // Constructor to initialize the product
    public Product(string name, string productId, decimal price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    // Method to get the total cost of the product
    public decimal GetTotalCost()
    {
        return price * quantity;
    }

    // Properties for encapsulation
    public string Name { get => name; }
    public string ProductId { get => productId; }
}

// Class that represents an address
public class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    // Constructor to initialize the address
    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    // Method to check if the address is in the USA
    public bool IsInUSA()
    {
        return country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    // Method to get the full address
    public string GetFullAddress()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

// Class that represents a customer
public class Customer
{
    private string name;
    private Address address;

    // Constructor to initialize the customer
    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    // Method to check if the customer lives in the USA
    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    // Properties for encapsulation
    public string Name { get => name; }
    public Address Address { get => address; }
}

// Class that represents an order
public class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;
    private decimal shippingCost;

    // Constructor to initialize the order
    public Order(Customer customer)
    {
        this.customer = customer;
        this.shippingCost = customer.IsInUSA() ? 5m : 35m; // Shipping cost based on location
    }

    // Method to add a product to the order
    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    // Method to calculate the total cost of the order
    public decimal CalculateTotal()
    {
        decimal total = shippingCost;
        foreach (Product product in products)
        {
            total += product.GetTotalCost();
        }
        return total;
    }

    // Method to get the packing label
    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product product in products)
        {
            label += $"{product.Name} (ID: {product.ProductId})\n";
        }
        return label;
    }

    // Method to get the shipping label
    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.Name}\n{customer.Address.GetFullAddress()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create some products
        Product product1 = new Product("Laptop", "P001", 999.99m, 1);
        Product product2 = new Product("Mouse", "P002", 29.99m, 2);
        Product product3 = new Product("Keyboard", "P003", 49.99m, 1);

        // Create addresses for customers
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");

        // Create customers
        Customer customer1 = new Customer("Alice", address1);
        Customer customer2 = new Customer("Bob", address2);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product2);

        // Display order details
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotal()}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotal()}\n");
    }
}

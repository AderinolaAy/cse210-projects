using System;
using System.Collections.Generic;

namespace OrderingSystem
{
    // Address class
    public class Address
    {
        private string street;
        private string city;
        private string state;
        private string country;

        public Address(string street, string city, string state, string country)
        {
            this.street = street;
            this.city = city;
            this.state = state;
            this.country = country;
        }

        public bool IsInUSA()
        {
            return country.ToUpper() == "USA";
        }

        public string GetFullAddress()
        {
            return $"{street}\n{city}, {state}\n{country}";
        }
    }

    // Customer class
    public class Customer
    {
        private string name;
        private Address address;

        public Customer(string name, Address address)
        {
            this.name = name;
            this.address = address;
        }

        public bool LivesInUSA()
        {
            return address.IsInUSA();
        }

        public string GetName()
        {
            return name;
        }

        public Address GetAddress()
        {
            return address;
        }
    }

    // Product class
    public class Product
    {
        private string name;
        private string productId;
        private double price;
        private int quantity;

        public Product(string name, string productId, double price, int quantity)
        {
            this.name = name;
            this.productId = productId;
            this.price = price;
            this.quantity = quantity;
        }

        public double GetTotalCost()
        {
            return price * quantity;
        }

        public string GetName()
        {
            return name;
        }

        public string GetProductId()
        {
            return productId;
        }
    }

    // Order class
    public class Order
    {
        private Customer customer;
        private List<Product> products;

        public Order(Customer customer)
        {
            this.customer = customer;
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public double GetTotalPrice()
        {
            double total = 0;
            foreach (Product p in products)
            {
                total += p.GetTotalCost();
            }

            // Shipping cost
            total += customer.LivesInUSA() ? 5 : 35;
            return total;
        }

        public string GetPackingLabel()
        {
            string label = "Packing Label:\n";
            foreach (Product p in products)
            {
                label += $"{p.GetName()} (ID: {p.GetProductId()})\n";
            }
            return label;
        }

        public string GetShippingLabel()
        {
            return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddress().GetFullAddress()}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create addresses
            Address addr1 = new Address("123 Main St", "New York", "NY", "USA");
            Address addr2 = new Address("45 Queen St", "Toronto", "ON", "Canada");

            // Create customers
            Customer cust1 = new Customer("Alice Johnson", addr1);
            Customer cust2 = new Customer("Bob Smith", addr2);

            // Create orders
            Order order1 = new Order(cust1);
            order1.AddProduct(new Product("Laptop", "P1001", 1200.00, 1));
            order1.AddProduct(new Product("Mouse", "P1002", 25.00, 2));

            Order order2 = new Order(cust2);
            order2.AddProduct(new Product("Headphones", "P2001", 150.00, 1));
            order2.AddProduct(new Product("Keyboard", "P2002", 75.00, 1));
            order2.AddProduct(new Product("Monitor", "P2003", 300.00, 2));

            // Store orders in a list
            List<Order> orders = new List<Order> { order1, order2 };

            // Display results
            foreach (Order order in orders)
            {
                Console.WriteLine(order.GetPackingLabel());
                Console.WriteLine(order.GetShippingLabel());
                Console.WriteLine($"Total Price: ${order.GetTotalPrice()}\n");
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}
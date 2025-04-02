using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
    public class Address
    {
        private string street;
        private string city;
        private string stateProvince;
        private string country;

        public Address(string street, string city, string stateProvince, string country)
        {
            this.street = street;
            this.city = city;
            this.stateProvince = stateProvince;
            this.country = country;
        }

        public bool IsUSA()
        {
            return country.ToUpper() == "USA";
        }

        public string GetFullAddress()
        {
            return $"{street}\n{city}, {stateProvince}\n{country}";
        }
    }

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
            return address.IsUSA();
        }

        public string Name => name;
        public Address Address => address;
    }

    public class Product
    {
        private string name;
        private int productId;
        private double price;
        private int quantity;

        public Product(string name, int productId, double price, int quantity)
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

        public string Name => name;
        public int ProductId => productId;
    }

    public class Order
    {
        private List<Product> products;
        private Customer customer;

        public Order(Customer customer)
        {
            this.customer = customer;
            this.products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public double GetTotalCost()
        {
            double productTotal = 0;
            foreach (var product in products)
            {
                productTotal += product.GetTotalCost();
            }

            double shippingCost = customer.LivesInUSA() ? 5.0 : 35.0;
            return productTotal + shippingCost;
        }

        public string GetPackingLabel()
        {
            string label = "Packing Label:\n";
            foreach (var product in products)
            {
                label += $"{product.Name} (ID: {product.ProductId})\n";
            }
            return label;
        }

        public string GetShippingLabel()
        {
            return $"Shipping Label:\n{customer.Name}\n{customer.Address.GetFullAddress()}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
            Customer customer1 = new Customer("John Doe", address1);

            Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");
            Customer customer2 = new Customer("Jane Smith", address2);

            Order order1 = new Order(customer1);
            order1.AddProduct(new Product("Laptop", 101, 1200.0, 1));
            order1.AddProduct(new Product("Mouse", 102, 25.0, 2));

            Order order2 = new Order(customer2);
            order2.AddProduct(new Product("Keyboard", 201, 80.0, 1));
            order2.AddProduct(new Product("Monitor", 202, 300.0, 1));
            order2.AddProduct(new Product("Headphones", 203, 50.0, 1));

            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Order 1 Cost: ${order1.GetTotalCost()}\n");

            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Order 2 Cost: ${order2.GetTotalCost()}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
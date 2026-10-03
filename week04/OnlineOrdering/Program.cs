using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Address domesticAddress = new Address(
            "123 Maple Street",
            "Springfield",
            "Illinois",
            "USA");
        Customer domesticCustomer = new Customer("Jordan Lee", domesticAddress);

        Order domesticOrder = new Order(domesticCustomer);
        domesticOrder.AddProduct(new Product("Notebook", "NB-104", 4.50m, 3));
        domesticOrder.AddProduct(new Product("Pen Set", "PS-208", 7.25m, 2));
        domesticOrder.AddProduct(new Product("Desk Organizer", "DO-315", 12.99m, 1));

        Address internationalAddress = new Address(
            "45 King Street",
            "Toronto",
            "Ontario",
            "Canada");
        Customer internationalCustomer = new Customer("Morgan Chen", internationalAddress);

        Order internationalOrder = new Order(internationalCustomer);
        internationalOrder.AddProduct(new Product("Travel Mug", "TM-410", 18.00m, 2));
        internationalOrder.AddProduct(new Product("Canvas Tote", "CT-522", 9.50m, 1));
        internationalOrder.AddProduct(new Product("Water Bottle", "WB-633", 15.75m, 1));

        DisplayOrder("Order 1", domesticOrder);
        DisplayOrder("Order 2", internationalOrder);
    }

    private static void DisplayOrder(string title, Order order)
    {
        Console.WriteLine($"=== {title} ===");
        Console.WriteLine("Packing label:");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine("Shipping label:");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total price: ${order.GetTotalCost().ToString("F2", CultureInfo.InvariantCulture)}");
        Console.WriteLine();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

var allProducts = ProductUtils.ListAllProducts();
ProductUtils.UpdateListOfAvailableProducts();

if (ProductUtils.ProductsAvailableNow.Count() == 0)
    Console.WriteLine("There are no products available at this time of day");
else
    ProductUtils.DisplayAvailableProducts();

Console.ReadKey();

public class Product
{
    public string ProductName;
    public string ProductType;
    public int StartHour, EndHour;
}

public static class ProductUtils
{
    public static IEnumerable<Product> ProductsAvailableNow;

    static ProductUtils()
    {
        ProductsAvailableNow = new List<Product>();
    }

    public static List<Product> ListAllProducts()
    {
        List<Product> allProducts = new List<Product>
        {
            new Product { ProductName = "Orange Juice", ProductType = "AllDay" },
            new Product { ProductName = "Breakfast Burrito", ProductType = "Limited", StartHour = 8, EndHour = 12 },
            new Product { ProductName = "Steak & Chips", ProductType = "Limited", StartHour = 12, EndHour = 21 },
            new Product { ProductName = "Chicken Sandwich", ProductType = "Limited", StartHour = 11, EndHour = 19 },
            new Product { ProductName = "Sam Adams Seasonal", ProductType = "Limited", StartHour = 17, EndHour = 23 }
        };

        return allProducts;
    }

    public static void UpdateListOfAvailableProducts()
    {
        var productList = (List<Product>)ProductsAvailableNow;

        productList.Clear();

        foreach (var product in ListAllProducts())
        {
            if (product.ProductType == "AllDay" || (product.StartHour <= DateTime.Now.Hour && product.EndHour >= DateTime.Now.Hour))
            {
                productList.Add(new Product
                {
                    ProductName = product.ProductName,
                    ProductType = product.ProductType,
                    StartHour = product.StartHour,
                    EndHour = product.EndHour
                });
            }
        }
    }

    public static void DisplayAvailableProducts()
    {
        Console.WriteLine("Products available current time of day:");

        foreach (var pan in ProductsAvailableNow)
        {
            string displayName = pan.ProductName;

            if (pan.ProductType == "AllDay")
                Console.WriteLine(pan.ProductName);
            else
            {
                displayName += " (" + pan.StartHour + ":00" + "-" + pan.EndHour + ":00" + ")";
                Console.WriteLine(displayName);
            }
        }
    }
}

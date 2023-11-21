using Uppgift_Databasteknik.Models;
using Uppgift_Databasteknik.Services;

namespace Uppgift_Databasteknik.Menus;

public class ProductMenu
{
    private readonly ProductService _productService;

    public ProductMenu(ProductService productService)
    {
        _productService = productService;
    }

    public async Task ManageProducts()
    {
        Console.Clear();
        Console.WriteLine("Products");
        Console.WriteLine("1. Add Product");
        Console.WriteLine("2. Show all Products");
        Console.Write("Choose one option: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await CreateAsync();
                break;
            case "2":
                await ListAllAsync();
                break;
        }
    }
    public async Task CreateAsync()
    {
        var form = new ProductRegistrationForm();

        Console.Clear();
        Console.Write("Product Name: ");
        form.ProductName = Console.ReadLine()!;

        Console.Write("Product Description: ");
        form.ProductDescription = Console.ReadLine()!;

        Console.Write("Category: ");
        form.ProductCategory = Console.ReadLine()!;

        Console.Write("Price(SEK): ");
        form.ProductPrice = decimal.Parse(Console.ReadLine()!);

        Console.Write("Pricing Unit(ST/TIM/PKT: ");
        form.PricingUnit = Console.ReadLine()!;

        var result = await _productService.CreateProductAsync(form);
        if (result)
            Console.WriteLine("Product was created successfully.");
        else
            Console.WriteLine("Unable to create Product");
        Console.ReadKey();
    }

    public async Task ListAllAsync()
    {
        var products = await _productService.GetAllAsync();
        foreach (var product in products)
        {
            Console.WriteLine($"{product.ProductName} {product.ProductPrice} SEK");

        }
        Console.ReadKey();
    }

}
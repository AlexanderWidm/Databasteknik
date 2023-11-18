namespace Uppgift_Databasteknik.Models;

public class ProductRegistrationForm
{
    public string ProductName { get; set; } = null!;
    public string ProductDescription { get; set; } = null!;
    public decimal ProductPrice { get; set; }
    public string ProductCategory { get; set; } = null!;
    public string PricingUnit { get; set; } = null!;
}

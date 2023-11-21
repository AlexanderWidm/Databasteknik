namespace Uppgift_Databasteknik.Models;

public class ShoppingCart
{
    public int CustomerId { get; set; }
    public List<CartItem> Items { get; set; } = new List<CartItem>();
}

public class CartItem
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uppgift_Databasteknik.Entities;

public class OrderRowEntity
{
    public int OrderId { get; set; }
    public OrderEntity Order { get; set; } = null!;
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
    public int Quantity { get; set; }
    public int QuantityUnitId { get; set; }
    public QuantityUnitEntity QuantityUnit { get; set; } = null!;
    [Column(TypeName = "money")]
    public int Price { get; set; }
}
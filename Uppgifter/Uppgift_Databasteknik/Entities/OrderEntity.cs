using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uppgift_Databasteknik.Entities;

public class OrderEntity
{
    [Key]
    public int Id { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public int CustomerId { get; set; }
    [Column(TypeName = "money")]
    public decimal TotalPrice { get; set; }
    public ICollection<OrderRowEntity> OrderRows { get; set; } = new List<OrderRowEntity>();
}

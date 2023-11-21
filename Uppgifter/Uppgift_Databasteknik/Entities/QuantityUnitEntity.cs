using System.ComponentModel.DataAnnotations;

namespace Uppgift_Databasteknik.Entities;

public class QuantityUnitEntity
{
    [Key]
    public int Id { get; set; }
    public string UnitName { get; set; } = null!;

    public ICollection<OrderRowEntity> OrderRows { get; set; } = new HashSet<OrderRowEntity>();
}

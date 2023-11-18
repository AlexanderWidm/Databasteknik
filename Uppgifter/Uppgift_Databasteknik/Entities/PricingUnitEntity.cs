using System.ComponentModel.DataAnnotations;

namespace Uppgift_Databasteknik.Entities;

public class PricingUnitEntity
{
    [Key]
    public int Id { get; set; }
    public string UnitName { get; set; } = null!;
}
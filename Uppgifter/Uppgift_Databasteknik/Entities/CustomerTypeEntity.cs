using System.ComponentModel.DataAnnotations;

namespace Uppgift_Databasteknik.Entities;

public class CustomerTypeEntity
{
    [Key]
    public int Id { get; set; }
    public string CustomerTypeName { get; set; } = null!;
}

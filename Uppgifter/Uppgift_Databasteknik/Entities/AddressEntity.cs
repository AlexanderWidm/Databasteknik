using System.ComponentModel.DataAnnotations;

namespace Uppgift_Databasteknik.Entities;

public class AddressEntity
{
    [Key]
    public int Id { get; set; }
    public string StreetName { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
}

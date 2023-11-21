using System.ComponentModel.DataAnnotations;

namespace Uppgift_Databasteknik.Entities;

public class CustomerEntity
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int AddressId { get; set; }
    public AddressEntity Address { get; set; } = null!;
    public int CustomerTypeId { get; set; }
    public CustomerTypeEntity CustomerType { get; set; } = null!;

    public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
}
 
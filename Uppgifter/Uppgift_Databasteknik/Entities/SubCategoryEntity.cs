using System.ComponentModel.DataAnnotations;

namespace Uppgift_Databasteknik.Entities;

public class SubCategoryEntity
{
    [Key]
    public int Id { get; set; }
    public string SubCategoryName { get; set; } = null!;
    public int PrimaryCategoryId { get; set; }
    public ProductCategoryEntity PrimaryCategory { get; set; } = null!;
    public ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();

}

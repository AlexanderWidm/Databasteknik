using Uppgift_Databasteknik.Contexts;
using Uppgift_Databasteknik.Entities;

namespace Uppgift_Databasteknik.Repositories;

public class ProductCategoryRepository : Repo<ProductCategoryEntity>
{
    public ProductCategoryRepository(DataContext context) : base(context)
    {
    }
}

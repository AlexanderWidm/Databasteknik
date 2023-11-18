using Uppgift_Databasteknik.Contexts;
using Uppgift_Databasteknik.Entities;

namespace Uppgift_Databasteknik.Repositories;

public class ProductRepository : Repo<ProductEntity>
{
    public ProductRepository(DataContext context) : base(context)
    {
    }
}

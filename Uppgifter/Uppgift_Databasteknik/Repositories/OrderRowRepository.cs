using Uppgift_Databasteknik.Contexts;
using Uppgift_Databasteknik.Entities;

namespace Uppgift_Databasteknik.Repositories;

public class OrderRowRepository : Repo<OrderRowEntity>
{
    public OrderRowRepository(DataContext context) : base(context)
    {
    }
}

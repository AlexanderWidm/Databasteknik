using Uppgift_Databasteknik.Contexts;
using Uppgift_Databasteknik.Entities;

namespace Uppgift_Databasteknik.Repositories;

public class PricingUnitRepository : Repo<PricingUnitEntity>
{
    public PricingUnitRepository(DataContext context) : base(context)
    {
    }
}

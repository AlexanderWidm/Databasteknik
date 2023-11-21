using Uppgift_Databasteknik.Contexts;

namespace Uppgift_Databasteknik.Repositories;

public class CustomerTypeRepository : Repo<CustomerTypeRepository>
{
    public CustomerTypeRepository(DataContext context) : base(context)
    {
    }
}

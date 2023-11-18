using Uppgift_Databasteknik.Contexts;
using Uppgift_Databasteknik.Entities;

namespace Uppgift_Databasteknik.Repositories;

public class AddressRepository : Repo<AddressEntity>
{
    public AddressRepository(DataContext context) : base(context)
    {
    }
}

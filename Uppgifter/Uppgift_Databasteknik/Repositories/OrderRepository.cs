using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Uppgift_Databasteknik.Contexts;
using Uppgift_Databasteknik.Entities;

namespace Uppgift_Databasteknik.Repositories;

public class OrderRepository : Repo<OrderEntity>
{
    private readonly DataContext _context;

    public OrderRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<OrderEntity> GetAsync(Expression<Func<OrderEntity, bool>> expression)
    {
        var order = await _context.Orders
            .Include(o => o.OrderRows)
            .ThenInclude(p => p.Product)
            .ThenInclude(p => p.ProductCategory)
            .FirstOrDefaultAsync(expression);

        if (order != null)
            return order;

        return null!;
    }

    public override async Task<IEnumerable<OrderEntity>> GetAllAsync()
    {
        var orders = await _context.Orders
            .Include(o => o.OrderRows)
            .ThenInclude(p => p.Product)
            .ThenInclude(p => p.ProductCategory)
            .ToListAsync();

        return orders;
    }
}

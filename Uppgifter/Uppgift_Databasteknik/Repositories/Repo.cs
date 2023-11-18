using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;
using Uppgift_Databasteknik.Contexts;

namespace Uppgift_Databasteknik.Repositories;

public abstract class Repo<TEntity> where TEntity : class
{
    private readonly DataContext _context;

    protected Repo(DataContext context)
    {
        _context = context;
    }


    // CREATE
    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
        try
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity ?? null!;
        } catch (Exception ex) { Debug.Write(ex); }
        return null!;
    }

    // READ
    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            return entity ?? null!;
        }
        catch (Exception ex) { Debug.Write(ex); }
        return null!;
    }

    // READ ALL
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        try
        {
            var entities = await _context.Set<TEntity>().ToListAsync();
            return entities ?? null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }

    // UPDATE
    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity ?? null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }

    // DELETE
    public virtual async Task<bool> RemoveAsync(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return false;
    }


    // IF EXISTS
    public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _context.Set<TEntity>().AnyAsync(expression);
    }
}

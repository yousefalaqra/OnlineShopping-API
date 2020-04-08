using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class Repository<T> : IRepository<T> where T : class, IEntity
{
    #region feilds

    private readonly AppDbContext _context;

    #endregion

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public Task<int> CountAll(Expression<Func<T, bool>> predicate = null)
    {
        if (predicate == null)
                predicate = x => true;

        return _context.Set<T>().CountAsync(predicate);
    }

    public Task<T> FirstOrDefault(Expression<Func<T, bool>> filter)
    {
        return _context.Set<T>().FirstOrDefaultAsync(filter);
    }

    public IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = ""
            )
    {
        IQueryable<T> result = _context.Set<T>();

        if(filter !=null)
        {
            result = result.Where(filter);
        }

        if(orderBy !=null)
        {
            result = orderBy(result);
        }

        foreach (string property in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
        {
            result = result.Include(property);   
        }

        return result.ToList();

    }

    public ValueTask<T> GetById(Guid id)
    {
        return _context.Set<T>().FindAsync(id);
    }

    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
}
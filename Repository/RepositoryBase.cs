using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Contracts;

namespace Repository;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly AppDbContext _appDbContext;

    protected RepositoryBase(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        DbSet = _appDbContext.Set<T>();
    }
    
    protected DbSet<T> DbSet { get; }

    public IQueryable<T> FindAll(bool trackChanges) =>
        !trackChanges
            ? DbSet.AsNoTracking()
            : DbSet;

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
        !trackChanges
            ? DbSet.Where(expression).AsNoTracking()
            : DbSet.Where(expression);

    public async Task Create(T entity) => await DbSet.AddAsync(entity);

    public void Update(T entity) => DbSet.Update(entity);

    public void Delete(T entity) => DbSet.Remove(entity);
}
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OnlineShopDAL.IRepositories;

namespace OnlineShopDAL.Repositories;

public class Repository<TEntity, TIdentity> : IRepository<TEntity, TIdentity> where TEntity : class
{
    protected readonly OnlineShopContext db;

    public Repository(OnlineShopContext context)
    {
        db = context;
    }

    public void Create(TEntity entity)
    {
        db.Set<TEntity>().Add(entity);
    }

    public void Remove(TEntity entity)
    {
        db.Set<TEntity>().Remove(entity);
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return db.Set<TEntity>().Where(predicate);
    }

    public TEntity Get(TIdentity id)
    {
        return db.Set<TEntity>().Find(id);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return db.Set<TEntity>();
    }

    public void Update(TEntity entity)
    {
        db.Entry(entity).State = EntityState.Modified;
    }


}
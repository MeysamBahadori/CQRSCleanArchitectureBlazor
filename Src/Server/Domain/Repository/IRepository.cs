using Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Domain.Repository;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    DbSet<TEntity> Entities { get; }
    IQueryable<TEntity> Table { get; }
    IQueryable<TEntity> TableNoTracking { get; }
    void Add(TEntity entity, bool saveNow = true);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
    void Delete(TEntity entity, bool saveNow = true);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
    TEntity? GetById(params object[] ids);
    ValueTask<TEntity?> GetByIdAsync(CancellationToken cancellationToken, params object[] ids);
    void Update(TEntity entity, bool saveNow = true);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
}

using Microsoft.EntityFrameworkCore;
using SEJE.CORE.Abstractions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace SEJE.EFCORE.Repository
{
    public interface IRepositoryBase<TKey, TUserKey>
    {
        TContext GetContext<TContext>() where TContext : DbContext;

        DbSet<TEntity> GetEntity<TEntity>() where TEntity : class, IEntityBase<TKey, TUserKey>;

        Task<TEntity> CreateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class, IEntityBase<TKey, TUserKey>;

        Task<bool> UpdateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class, IEntityBase<TKey, TUserKey>;

        Task<bool> DeleteAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default) where TEntity : class, IEntityBase<TKey, TUserKey>;

        Task<List<TEntity>> CreateRangeAsync<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : class, IEntityBase<TKey, TUserKey>;

        Task<bool> UpdateRangeAsync<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : class, IEntityBase<TKey, TUserKey>;

        Task<bool> DeleteRangeAsync<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : class, IEntityBase<TKey, TUserKey>;

        Task<TResult> TransactionAsync<TResult>(Func<DbContext, Task<TResult>> process, IsolationLevel isolation = IsolationLevel.ReadUncommitted, CancellationToken cancellationToken = default);
    }
}

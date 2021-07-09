using Microsoft.EntityFrameworkCore;
using SEJE.CORE.Abstractions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace SEJE.EFCORE.Repository
{
    public abstract class RepositoryBase<TKey, TUserKey> : IRepositoryBase<TKey, TUserKey>
    {
        protected readonly DbContext Context;

        protected RepositoryBase(DbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public TContext GetContext<TContext>() where TContext : DbContext => (TContext)this.Context;

        public DbSet<TEntity> GetEntity<TEntity>() where TEntity : class, IEntityBase<TKey, TUserKey> => this.Context.Set<TEntity>();

        public Task<TEntity> CreateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class, IEntityBase<TKey, TUserKey>
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return this.ProcessCreateAsync(entity, cancellationToken);
        }

        private async Task<TEntity> ProcessCreateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class, IEntityBase<TKey, TUserKey>
        {
            await this.Context.AddAsync(entity, cancellationToken);

            await this.Context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public Task<bool> UpdateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class, IEntityBase<TKey, TUserKey>
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return this.ProcessUpdateAsync(entity, cancellationToken);
        }

        private async Task<bool> ProcessUpdateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class, IEntityBase<TKey, TUserKey>
        {
            this.Context.Set<TEntity>().Update(entity);

            this.Context.Entry(entity).Property(nameof(IEntityBase<TKey, TUserKey>.CreatedById)).IsModified = false;
            this.Context.Entry(entity).Property(nameof(IEntityBase<TKey, TUserKey>.CreationDate)).IsModified = false;

            var success = await this.Context.SaveChangesAsync(cancellationToken) > 0;

            return success;
        }

        public Task<bool> DeleteAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default) where TEntity : class, IEntityBase<TKey, TUserKey>
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return this.ProcessDeleteAsync(predicate, cancellationToken);
        }

        private async Task<bool> ProcessDeleteAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken) where TEntity : class, IEntityBase<TKey, TUserKey>
        {
            var entity = await this.Context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();

            if (entity != null)
            {
                this.Context.Set<TEntity>().Remove(entity);

                return await this.Context.SaveChangesAsync(cancellationToken) > 0;
            }

            return false;
        }

        public async Task<List<TEntity>> CreateRangeAsync<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : class, IEntityBase<TKey, TUserKey>
        {
            if (!entities.Any())
                return entities;

            return await ProcessCreateRangeAsync(entities, cancellationToken);
        }

        private async Task<List<TEntity>> ProcessCreateRangeAsync<TEntity>(List<TEntity> entities, CancellationToken cancellationToken) where TEntity : class, IEntityBase<TKey, TUserKey>
        {
            await this.Context.AddRangeAsync(entities, cancellationToken);

            await this.Context.SaveChangesAsync(cancellationToken);

            return entities;
        }

        public async Task<bool> UpdateRangeAsync<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : class, IEntityBase<TKey, TUserKey>
        {
            if (!entities.Any())
                return false;

            this.Context.UpdateRange(entities);

            return await this.Context.SaveChangesAsync(cancellationToken) == entities.Count;
        }

        public async Task<bool> DeleteRangeAsync<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : class, IEntityBase<TKey, TUserKey>
        {
            if (!entities.Any())
                return false;

            this.Context.RemoveRange(entities);

            return await this.Context.SaveChangesAsync(cancellationToken) == entities.Count;
        }

        public async Task<bool> ChangeStateAsync<TEntity>(TKey id, bool state, CancellationToken cancellationToken = default) where TEntity : class, IEntityBase<TKey, TUserKey>
        {
            var entity = await this.Context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (entity != null)
            {
                entity.Removed = state;

                return await this.Context.SaveChangesAsync(cancellationToken) > 0;
            }

            return false;
        }

        public async Task<TResult> TransactionAsync<TResult>(Func<DbContext, Task<TResult>> process, IsolationLevel isolation = IsolationLevel.ReadUncommitted, CancellationToken cancellationToken = default)
        {
            var strategy = this.Context.Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async (cancellation) =>
            {
                using var transaction = await this.Context.Database.BeginTransactionAsync(isolation, cancellation);

                var result = await process(this.Context);

                await transaction.CommitAsync();

                return result;
            }, cancellationToken);
        }

    }


}


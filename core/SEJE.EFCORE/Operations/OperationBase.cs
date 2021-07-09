using Microsoft.EntityFrameworkCore;
using SEJE.CORE.Abstractions;
using SEJE.EFCORE.Middleware;
using SEJE.EFCORE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SEJE.EFCORE.Operations
{
    public abstract class OperationBase<TKey, TUserKey, TEntity> : RepositoryBase<TKey, TUserKey>, IOperationBase<TKey, TUserKey, TEntity>
        where TEntity : class, IEntityBase<TKey, TUserKey>
    {

        private readonly List<string> blacklist = new List<string>() {
            nameof(IEntityBase<TKey, TUserKey>.Id),
            nameof(IEntityBase<TKey, TUserKey>.CreatedById),
            nameof(IEntityBase<TKey, TUserKey>.CreationDate),
            nameof(IEntityBase<TKey, TUserKey>.ModifiedById),
            nameof(IEntityBase<TKey, TUserKey>.ModificationDate),
            nameof(IEntityBase<TKey, TUserKey>.Removed)
        };

        protected readonly IAuthenticateUser<TUserKey> AuthenticateUser;

        protected OperationBase(IAuthenticateUser<TUserKey> authenticatetUser, DbContext context) : base(context)
        {
            this.AuthenticateUser = authenticatetUser;
        }

        public virtual async Task<TKey> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.CreatedById = this.AuthenticateUser.IdUser;
            entity.CreationDate = DateTime.Now;
            entity.ModifiedById = this.AuthenticateUser.IdUser;
            entity.ModificationDate = DateTime.Now;

            entity = await base.CreateAsync(entity, cancellationToken);

            return entity.Id;
        }

        public virtual Task<bool> DeleteAsync(TKey id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync<TEntity>(x => x.Id.Equals(id), cancellationToken);
        }

        public virtual async Task<bool> UpdateAsync(TKey id, TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.ModifiedById = this.AuthenticateUser.IdUser;
            entity.ModificationDate = DateTime.Now;

            var entityUpdated = await base.GetEntity<TEntity>().FindAsync(id);

            if (entityUpdated != null)
            {
                var properties = typeof(TEntity).GetProperties().Where(x => !this.blacklist.Contains(x.Name)).ToList();

                foreach (var property in properties)
                {
                    var value = entity.GetType().GetProperty(property.Name).GetValue(entity);

                    if (value != null)
                        entityUpdated.GetType().GetProperty(property.Name).SetValue(entityUpdated, value, null);
                }

                return await base.Context.SaveChangesAsync() > 0;
            }

            return false;
        }

    }
}

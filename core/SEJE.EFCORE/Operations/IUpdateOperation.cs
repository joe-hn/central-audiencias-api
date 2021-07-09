using SEJE.CORE.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace SEJE.EFCORE.Operations
{
    public interface IUpdateOperation<TKey, TUserKey, TEntity> where TEntity : class, IEntityBase<TKey, TUserKey>
    {
        Task<bool> UpdateAsync(TKey id, TEntity entity, CancellationToken cancellationToken = default);
    }
}

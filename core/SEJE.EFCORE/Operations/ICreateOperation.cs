using SEJE.CORE.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace SEJE.EFCORE.Operations
{
    public interface ICreateOperation<TKey, TUserKey, TEntity> where TEntity : class, IEntityBase<TKey, TUserKey>
    {
        Task<TKey> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}

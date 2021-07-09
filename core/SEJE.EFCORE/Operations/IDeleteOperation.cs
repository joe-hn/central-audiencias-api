using SEJE.CORE.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace SEJE.EFCORE.Operations
{
    public interface IDeleteOperation<TKey, TUserKey, TEntity> where TEntity : class, IEntityBase<TKey, TUserKey>
    {
        Task<bool> DeleteAsync(TKey id, CancellationToken cancellationToken = default);
    }
}

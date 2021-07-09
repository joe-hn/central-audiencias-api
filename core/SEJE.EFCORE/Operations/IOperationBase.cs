using SEJE.CORE.Abstractions;
using SEJE.EFCORE.Repository;

namespace SEJE.EFCORE.Operations
{
    public interface IOperationBase<TKey, TUserKey, TEntity> :
        ICreateOperation<TKey, TUserKey, TEntity>,
        IUpdateOperation<TKey, TUserKey, TEntity>,
        IDeleteOperation<TKey, TUserKey, TEntity>,
        IRepositoryBase<TKey, TUserKey>
        where TEntity : class, IEntityBase<TKey, TUserKey>
    { }
}

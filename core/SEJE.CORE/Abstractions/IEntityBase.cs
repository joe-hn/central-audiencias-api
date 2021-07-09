namespace SEJE.CORE.Abstractions
{
    public interface IEntityBase : IBase
    {
    }

    public interface IEntityBase<TKey, TUserKey> : IBase<TKey, TUserKey>, IEntityBase
    {

    }
}

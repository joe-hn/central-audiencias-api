namespace SEJE.CORE.Abstractions
{
    public interface IDtoBase
    {
    }

    public interface IDtoBase<TKey, TUserKey> : IBase<TKey, TUserKey>, IDtoBase
    {

    }
}

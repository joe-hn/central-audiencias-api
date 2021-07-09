namespace SEJE.EFCORE.Middleware
{
    public interface IIdentityService<TUserKey>
    {
        IAuthenticateUser<TUserKey> BuildAuthenticateUser();
    }
}

namespace SEJE.EFCORE.Middleware
{
    public interface IAuthenticateUser<TKeyUser>
    {
        bool IsApplication { get; set; }
        TKeyUser IdUser { get; set; }
        bool IsAuthenticated { get; set; }
        string Name { get; set; }
        string Email { get; set; }
    }
}

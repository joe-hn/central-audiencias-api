namespace SEJE.EFCORE.Middleware
{
    public class AuthenticateUser<TKeyUser> : IAuthenticateUser<TKeyUser>
    {
        public bool IsApplication { get; set; }
        public TKeyUser IdUser { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}

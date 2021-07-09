using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SEJE.EFCORE.Options;
using System;
using System.Security.Principal;

namespace SEJE.EFCORE.Middleware
{
    public class IdentityService<TUserKey> : IIdentityService<TUserKey>
    {
        private readonly IIdentity identity;
        private readonly EFCoreOption efCoreOptions;
        private readonly IAuthenticateUser<TUserKey> authenticateUser;
        private readonly IHttpContextAccessor httpContextAccessor;

        public IdentityService(IOptions<EFCoreOption> options, IHttpContextAccessor httpContextAccessor, IAuthenticateUser<TUserKey> authenticateUser)
        {
            this.efCoreOptions = options.Value;
            this.httpContextAccessor = httpContextAccessor;
            this.identity = httpContextAccessor.HttpContext.User.Identity;
            this.authenticateUser = authenticateUser;
        }

        public IAuthenticateUser<TUserKey> BuildAuthenticateUser()
        {
            this.authenticateUser.IsAuthenticated = this.identity.IsAuthenticated;

            if (this.authenticateUser.IsAuthenticated)
            {
                this.authenticateUser.Name = this.GetUser();
                this.authenticateUser.Email = this.GetEmail();
                this.authenticateUser.IdUser = this.GetIdUser();
                this.authenticateUser.IsApplication = this.IsApplication();
            }

            return this.authenticateUser;
        }

        private string GetUser() => this.GetClaimValue(this.efCoreOptions.ClaimsIdentity.User);

        private string GetEmail() => this.GetClaimValue(this.efCoreOptions.ClaimsIdentity.Email);

        private TUserKey GetIdUser()
        {
            var idUser = this.httpContextAccessor.HttpContext.User.FindFirst(this.efCoreOptions.ClaimsIdentity.IdUser);

            if (idUser != null)
                return (TUserKey)Convert.ChangeType(idUser.Value, typeof(TUserKey));

            return default;
        }

        private bool IsApplication()
        {
            var role = this.httpContextAccessor.HttpContext.User.FindFirst(this.efCoreOptions.ClaimsIdentity.Role);

            return role == null;
        }

        private string GetClaimValue(string claimType)
        {
            var user = this.httpContextAccessor.HttpContext.User.FindFirst(claimType);

            if (user != null)
                return user.Value;

            return default;
        }
    }
}

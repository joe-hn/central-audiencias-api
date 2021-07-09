using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SEJE.EFCORE.Middleware
{
    public class IdentityServiceMiddleware<TUserKey>
    {
        private readonly RequestDelegate next;

        public IdentityServiceMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, IIdentityService<TUserKey> identityService)
        {
            identityService.BuildAuthenticateUser();

            await this.next(context);
        }
    }
}

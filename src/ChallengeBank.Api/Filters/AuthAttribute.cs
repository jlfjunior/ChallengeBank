using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeBank.Api.Filters
{
    public class AuthAttribute : Attribute, IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var secret = context.HttpContext.Request.Headers.FirstOrDefault(x => x.Key.ToUpper() == "Secret".ToUpper()).Value;

            if (!secret.Equals("1234567890"))
                context.Result = new UnauthorizedResult();


        }
    }
}

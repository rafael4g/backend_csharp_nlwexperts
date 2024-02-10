using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace webapi.filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
      var token = TokenOnRequest(context.HttpContext);
    }

    private string TokenOnRequest(HttpContext context)
    {
      //"Bearer Y3Jpc3RpYW5vQGNyaXN0aWFuby5jb20="
      var authentication = context.Request.Headers.Authorization.ToString();
      return authentication["Bearer ".Length..];

    }
}

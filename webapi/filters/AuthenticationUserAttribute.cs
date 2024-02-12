using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using webapi.Contracts;

namespace webapi.filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
  private readonly IUserRepository _repository;

  public AuthenticationUserAttribute(IUserRepository repository) => _repository = repository;


  public void OnAuthorization(AuthorizationFilterContext context)
  {
    try
    {
      var token = TokenOnRequest(context.HttpContext);

      var email = FromBase64String(token);

      var exist = _repository.ExistUserWithEmail(email);

      if (exist == false)
      {
        context.Result = new UnauthorizedObjectResult("E-mail not valid");
      }
    }
    catch (Exception ex)
    {

      context.Result = new UnauthorizedObjectResult(ex.Message);
    }

  }

  private static string TokenOnRequest(HttpContext context)
  {

    var authentication = context.Request.Headers.Authorization.ToString();

    if (string.IsNullOrEmpty(authentication))
    {
      throw new Exception("Token is missing.");
    }

    var tokenOutput = authentication["Bearer ".Length..];

    return tokenOutput;
  }

  private static string FromBase64String(string base64)
  {
    var data = Convert.FromBase64String(base64);
    //return System.Text.Encoding.UTF8.GetString(data);
    return System.Text.Encoding.UTF8.GetString(data);
  }
}

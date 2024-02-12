using webapi.Contracts;
using webapi.Entities;

namespace webapi.Services;

public class LoggedUser
{
  private readonly IHttpContextAccessor _httpContextAccessor;
  private readonly IUserRepository _repository;
  public LoggedUser(IHttpContextAccessor httpContext, IUserRepository repository)
  {
    _httpContextAccessor = httpContext;
    _repository = repository;
  }
  public User User()
  {

    var token = TokenOnRequest(_httpContextAccessor);

    var email = FromBase64String(token);

    var firstUserFinded = _repository.GetUserByEmail(email);

    return firstUserFinded;
  }

  private static string TokenOnRequest(IHttpContextAccessor httpContextAccessor)
  {

    var authentication = httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

    var tokenOutput = authentication["Bearer ".Length..];

    return tokenOutput;
  }

  private static string FromBase64String(string base64)
  {
    var data = Convert.FromBase64String(base64);

    return System.Text.Encoding.UTF8.GetString(data);
  }
}

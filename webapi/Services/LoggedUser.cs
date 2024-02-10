using webapi.Entities;
using webapi.Repositories;

namespace webapi.Services;

public class LoggedUser
{
  private readonly IHttpContextAccessor _httpContextAccessor;
  public LoggedUser(IHttpContextAccessor httpContext)
  {
    _httpContextAccessor = httpContext;
  }
  public User User()
  {
    var repository = new WebapiAuctionDbContext();

    var token = TokenOnRequest(_httpContextAccessor);

    var email = FromBase64String(token);

    var firstUserFinded = repository.Users.First(user => user.Email.Equals(email));

    return firstUserFinded;
  }

  private static string TokenOnRequest(IHttpContextAccessor httpContextAccessor)
  {

    var authentication = httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

    var tokenOutput = authentication["Bearer ".Length..];

    return tokenOutput;
  }

  private string FromBase64String(string base64)
  {
    var data = Convert.FromBase64String(base64);

    return System.Text.Encoding.UTF8.GetString(data);
  }
}

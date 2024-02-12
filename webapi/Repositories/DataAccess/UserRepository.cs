using webapi.Contracts;
using webapi.Entities;

namespace webapi.Repositories.DataAccess;

public class UserRepository : IUserRepository
{
  private readonly WebapiAuctionDbContext _dbContext;
  public UserRepository(WebapiAuctionDbContext dbContext) => _dbContext = dbContext;

  public bool ExistUserWithEmail(string email)
  {
    return _dbContext.Users!.Any(user => user.Email.Equals(email));
  }

  public User GetUserByEmail(string email) => _dbContext.Users!.First(user => user.Email.Equals(email));
}

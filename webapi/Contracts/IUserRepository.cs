using webapi.Entities;

namespace webapi.Contracts;

public interface IUserRepository
{
  bool ExistUserWithEmail(string email);
  User GetUserByEmail(string email);
}

using webapi.Entities;

namespace webapi.Contracts;

public interface IAuctionRepository
{
  Auction? GetCurrent();
}

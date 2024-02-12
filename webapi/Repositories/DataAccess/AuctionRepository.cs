using Microsoft.EntityFrameworkCore;
using webapi.Contracts;
using webapi.Entities;

namespace webapi.Repositories.DataAccess;

public class AuctionRepository : IAuctionRepository
{
  private readonly WebapiAuctionDbContext _dbContext;
  public AuctionRepository(WebapiAuctionDbContext dbContext) => _dbContext = dbContext;

  public Auction? GetCurrent()
  {
    var today = DateTime.Now;
#pragma warning disable CS8604 // Possible null reference argument.
    return _dbContext
        .Auctions
        .Include(auction => auction.Items)
        .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
#pragma warning restore CS8604 // Possible null reference argument.
  }
}

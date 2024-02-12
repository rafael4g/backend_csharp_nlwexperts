using webapi.Contracts;
using webapi.Entities;

namespace webapi.Repositories.DataAccess;

public class OfferRepository : IOfferRepository
{
  private readonly WebapiAuctionDbContext _dbContext;
  public OfferRepository(WebapiAuctionDbContext dbContext) => _dbContext = dbContext;
  public void Add(Offer offer)
  {
    _dbContext.Offers!.Add(offer);

    _dbContext.SaveChanges();
  }
}

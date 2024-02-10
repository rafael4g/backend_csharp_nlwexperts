using Microsoft.EntityFrameworkCore;
using webapi.Entities;
using webapi.Repositories;

namespace webapi.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    public Auction? Execute()
    {
      var repository = new webapiAuctionDbContext();
      var today = DateTime.Now;


#pragma warning disable CS8604 // Possible null reference argument.
        return repository
            .Auctions
            .Include(auction  => auction.Items)
            .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
#pragma warning restore CS8604 // Possible null reference argument.
    }
}

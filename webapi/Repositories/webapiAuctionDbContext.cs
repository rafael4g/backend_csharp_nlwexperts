using Microsoft.EntityFrameworkCore;
using webapi.Entities;
namespace webapi.Repositories;

public class WebapiAuctionDbContext : DbContext
{
  public WebapiAuctionDbContext(DbContextOptions options) : base(options) { }
  public DbSet<Auction>? Auctions { get; set; }
  public DbSet<User>? Users { get; set; }
  public DbSet<Offer>? Offers { get; set; }
}

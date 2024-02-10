using Microsoft.EntityFrameworkCore;
using webapi.Entities;
namespace webapi.Repositories;

public class WebapiAuctionDbContext : DbContext
{
  public DbSet<Auction>? Auctions { get; set; }
  public DbSet<User>? Users { get; set; }
  public DbSet<Offer>? Offers { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    string pathDbSqlite = "/home/rafael/www/nlw-csharp/leilaoDbNLW.db";
    optionsBuilder.UseSqlite($"Data Source={pathDbSqlite}");
  }
}

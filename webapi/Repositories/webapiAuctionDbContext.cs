using Microsoft.EntityFrameworkCore;
using webapi.Entities;
namespace webapi.Repositories;

public class webapiAuctionDbContext : DbContext
{
  public DbSet<Auction>? Auctions { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      string pathDbSqlite = "/home/rafael/www/nlw-csharp/leilaoDbNLW.db";
      optionsBuilder.UseSqlite($"Data Source={pathDbSqlite}");
    }
}

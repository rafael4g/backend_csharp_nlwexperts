
using webapi.Contracts;
using webapi.Entities;


namespace webapi.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    private readonly IAuctionRepository _repository;
    public GetCurrentAuctionUseCase(IAuctionRepository repository) => _repository = repository;
    public Auction? Execute() => _repository.GetCurrent();
}

using webapi.Entities;

namespace webapi.Contracts;

public interface IOfferRepository
{
  void Add(Offer offer);
}

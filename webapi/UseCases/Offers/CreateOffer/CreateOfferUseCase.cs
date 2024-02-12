using webapi.Communication.Requests;
using webapi.Contracts;
using webapi.Entities;
using webapi.Services;

namespace webapi.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
  private readonly LoggedUser _loggedUser;
  private readonly IOfferRepository _repository;
  //start Construtor
  public CreateOfferUseCase(
    LoggedUser loggedUser,
    IOfferRepository repository)
  {
    _loggedUser = loggedUser;
    _repository = repository;
  }
  //end Construtor
  public int Execute(int itemId, RequestCreateOfferJson request)
  {

    var user = _loggedUser.User();

    var offer = new Offer
    {
      CreatedOn = DateTime.Now,
      ItemId = itemId,
      Price = request.Price,
      UserId = user.Id,
    };

    _repository.Add(offer);

    return offer.Id;

  }
}
using System;
using webapi.Communication.Requests;
using webapi.Entities;
using webapi.Repositories;
using webapi.Services;

namespace webapi.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
  private readonly LoggedUser _loggedUser;
  //start Construtor
  public CreateOfferUseCase(LoggedUser loggedUser) => _loggedUser = loggedUser;
  //end Construtor
  public int Execute(int itemId,
                     RequestCreateOfferJson request)
  {
    var repository = new WebapiAuctionDbContext();

    var user = _loggedUser.User();

    var offer = new Offer
    {
      CreatedOn = DateTime.Now,
      ItemId = itemId,
      Price = request.Price,
      UserId = user.Id,
    };

    repository.Offers.Add(offer);

    repository.SaveChanges();

    return offer.Id;

  }
}
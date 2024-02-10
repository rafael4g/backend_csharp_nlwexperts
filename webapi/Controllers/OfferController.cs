using Microsoft.AspNetCore.Mvc;
using webapi.Communication.Requests;
using webapi.filters;
using webapi.UseCases.Offers.CreateOffer;
namespace webapi.Controllers;


[ServiceFilter(typeof(AuthenticationUserAttribute))]
public class OfferController : WebapiAuctionBaseController
{
  [HttpPost]
  [Route("{itemId}")]

  public IActionResult CreateOffer(
    [FromRoute] int itemId,
    [FromBody] RequestCreateOfferJson request,
    [FromServices] CreateOfferUseCase useCase)
  {
    var id = useCase.Execute(itemId, request);
    return Created(string.Empty, id);
  }
}

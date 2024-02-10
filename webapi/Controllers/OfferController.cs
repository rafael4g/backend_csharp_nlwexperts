using Microsoft.AspNetCore.Mvc;
using webapi.Communication.Requests;
using webapi.filters;
namespace webapi.Controllers;


[ServiceFilter(typeof(AuthenticationUserAttribute))]
public class OfferController : WebapiAuctionBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    
    public IActionResult CreateOffer([FromRoute] int itemId, [FromBody] RequestCreateOfferJson request)
    {
      return Ok();
    }    
}

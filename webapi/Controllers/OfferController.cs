using Microsoft.AspNetCore.Mvc;
using webapi.Communication.Requests;
namespace webapi.Controllers;

public class OfferController : WebapiAuctionBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    public IActionResult CreateOffer([FromRoute] int itemId, [FromBody] RequestCreateOfferJson request)
    {
      return Ok();
    }    
}

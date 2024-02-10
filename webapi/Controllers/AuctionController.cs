using Microsoft.AspNetCore.Mvc;
using webapi.Entities;
using webapi.UseCases.Auctions.GetCurrent;

namespace webapi.Controllers;
public class AuctionController : WebapiAuctionBaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentAuction()
    {
        var UseCase = new GetCurrentAuctionUseCase();
        var result = UseCase.Execute();

        if (result is null)
            return NoContent();
        return Ok(result);
    }
}

using Microsoft.AspNetCore.Mvc;
using webapi.Entities;
using webapi.UseCases.Auctions.GetCurrent;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuctionController : ControllerBase
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

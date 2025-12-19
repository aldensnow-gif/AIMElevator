using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
/// <summary>
/// Default API Controller for Elevator operations. 
/// </summary>
[ApiController]
[Route("[action]")]
public class DefaultApiController : ControllerBase
{
    /// <summary>
    /// Pass in the floor number to call the elevator to.
    /// </summary>
    /// <param name="floorNumber">Floor number (1-13). Example: 3</param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public IActionResult CallToFloor([FromBody, Range(1, 13)] int floorNumber, CancellationToken ct)
        => Accepted();

    /// <summary>
    /// Get a list of the floors that need servicing.
    /// </summary>
    /// <returns>Array of floor numbers between (1-13). Example: [1,3]</returns>
    [HttpGet]
    [ProducesResponseType(typeof(int[]), StatusCodes.Status200OK)]
    public IActionResult RequestsServicing(CancellationToken ct)
        => Ok(Array.Empty<int>());

    /// <summary>
    /// Get the next floor to service.
    /// </summary>
    /// <returns>A floor number between (1-13). Example: 3</returns>
    [HttpGet]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult NextFloor(CancellationToken ct)
        => NoContent();
}

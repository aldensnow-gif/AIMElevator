using Microsoft.AspNetCore.Mvc;
using AIMElevator.api.CallToFloor;
using Org.OpenAPITools.Models;
    [ApiController]
    public class DefaultApiController : ControllerBase
    { 
        private readonly ICallToFloorHandler _handler;

        public DefaultApiController(ICallToFloorHandler handler)
            => _handler = handler;

        [HttpPost]
        [Route("/CallToFloor")]
        [Consumes("application/json")]
        public Task<IActionResult> CallToFloor([FromBody] FloorNumber floorNumber, CancellationToken ct)
        => _handler.HandleAsync(floorNumber, ct);
    }
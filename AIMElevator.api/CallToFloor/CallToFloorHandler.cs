using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Org.OpenAPITools.Models;

namespace AIMElevator.api.CallToFloor
{
    public class CallToFloorHandler : ICallToFloorHandler
    {
        public Task<IActionResult> HandleAsync(FloorNumber floorNumber, CancellationToken ct)
        {
            return Task.FromResult<IActionResult>(new StatusCodeResult(StatusCodes.Status501NotImplemented));
        }
    }
}
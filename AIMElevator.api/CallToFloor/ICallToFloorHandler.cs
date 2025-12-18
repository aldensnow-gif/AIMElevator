using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AIMElevator.api.CallToFloor;
using Org.OpenAPITools.Models;
namespace AIMElevator.api.CallToFloor
{
    public interface ICallToFloorHandler
    {
        Task<IActionResult> HandleAsync(FloorNumber floorNumber, CancellationToken ct);
    }
}
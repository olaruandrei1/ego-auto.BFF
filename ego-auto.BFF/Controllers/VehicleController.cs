
using ego_auto.BFF.Application.Contracts;
using ego_auto.BFF.Domain.Dtos;
using ego_auto.BFF.Domain.Requests;
using ego_auto.BFF.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace ego_auto.BFF.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehicleController(IVehicleService _service) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetVehiclesAsync([FromQuery] GetVehiclesRequest request)     
    => Ok(await _service.GetVehiclesAsync(request));

    [HttpPost]
    public async Task<IActionResult> UpsertVehicleAsync([FromBody] VehicleUpsertDto request)
    => Ok(await _service.UpsertVehicleAsync(request));

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetVehicle(int id)
    => Ok(await _service.GetVehicleAsync(id));
}

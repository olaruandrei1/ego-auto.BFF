
using ego_auto.BFF.Application.Contracts;
using ego_auto.BFF.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace ego_auto.BFF.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehicleController(IVehicleService _service) : BaseController
{
}

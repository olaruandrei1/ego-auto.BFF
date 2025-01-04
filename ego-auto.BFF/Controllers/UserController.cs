using ego_auto.BFF.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ego_auto.BFF.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService _service) : ControllerBase
{
}

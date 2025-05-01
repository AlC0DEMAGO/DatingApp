using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
using API.Helpers;
[ServiceFilter(typeof(LogUserActivity))]
[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
    
}
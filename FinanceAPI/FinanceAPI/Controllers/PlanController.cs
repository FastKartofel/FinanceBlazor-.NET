using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAPI.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        [HttpGet("plan")]
        public IActionResult GetPlan()
        {
            return Ok("Hello user, welcome to your plan.");
        }
    }
}
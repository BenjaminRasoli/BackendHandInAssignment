using Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeLinesController(ITimeLineService timeLineService) : ControllerBase
    {
        private readonly ITimeLineService _timeLineService = timeLineService;

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var result = await _timeLineService.GetTimeLinesAsync();
            return Ok(result);
        }
    }
}

using food_truck_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace food_truck_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounterController : Controller
    {
        private readonly CounterService _counterService;

        public CounterController(CounterService counterService)
        {
            _counterService = counterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCounterCount()
        {
            var result = await _counterService.GetCounterCount();
            return Ok(result);
        }

        [HttpGet]
        [Route("click")]
        public async Task<IActionResult> IncrementCounter()
        {
            var result = await _counterService.IncrementCounter();
            return Ok(result);
        }
    }
}

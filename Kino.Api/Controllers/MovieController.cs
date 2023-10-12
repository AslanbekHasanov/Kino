using Kino.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Kino.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MovieController: ControllerBase
    {
        private readonly IService _service;

        public MovieController(IService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMoveis()
        {
            var res = await _service.GetAllMoveisAsync();

            return Ok(res);

        }
    }

}

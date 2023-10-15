using Kino.Api.Model;
using Kino.Api.Repository;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> GetMoveis(int moveiId)
        {
            var res = await _service.GetByIdMoveisAsync(moveiId);
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMoveis()
        {
            var res = await _service.GetAllMoveisAsync();

            return Ok(res);

        }
        [HttpPost]
        public async Task<IActionResult> AddMoveis([FromForm]Moveis moveis )
        {
            await _service.AddMoveisAsync(moveis);
            return Ok(moveis);

        }
        [HttpPost]
        public async Task<IActionResult> SetImage(int id, IFormFile file)
        {
             var res = await _service.SetImageAsync(id, file);
            return Ok(res);
        }

    }

}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Repos.Models;
using webapi.Services;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseTonerController : ControllerBase
    {
        private readonly IbaseTonerService ibaseTonerService;
        public BaseTonerController(IbaseTonerService ibaseTonerService)
        {
            this.ibaseTonerService = ibaseTonerService;
        }

        [HttpGet("GetAllToner")]
        public async Task<ActionResult> Get()
        {
            var data = await ibaseTonerService.GetAllToner();
            if(data==null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpPost("CreateToner")]
        public async Task<IActionResult> CreateBase(BaseToner baseToner)
        {
            var data = await ibaseTonerService.CreateToner(baseToner);
            return Ok(data);
        }
        [HttpPut("UpdateToner")]
        public async Task<IActionResult> UpdateToner(BaseToner baseToner)
        {
            var data = await ibaseTonerService.UpdateToner(baseToner);
            return Ok(data);
        }
        [HttpDelete("RemoveToner")]
        public async Task<IActionResult> RemoveToner(string Reference)
        {
            var data = await ibaseTonerService.RemoveToner(Reference);
            return Ok(data);
        }
    }
}

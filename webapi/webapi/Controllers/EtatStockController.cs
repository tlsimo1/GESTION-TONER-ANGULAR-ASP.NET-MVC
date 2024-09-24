using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Container;
using webapi.Repos.Models;
using webapi.Services;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtatStockController : ControllerBase
    {
        private readonly IEtat_stockServices Ietat_stockServices;
        public EtatStockController(IEtat_stockServices Ietat_stockServices)
        {
            this.Ietat_stockServices = Ietat_stockServices;
        }
        [HttpGet("GetAll_EtatStock")]
        public async Task<ActionResult> Get()
        {
            var data= await Ietat_stockServices.GetAll_EtatStock();
            if(data==null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpPost("Update_EtatStock")]
        public async Task<IActionResult> UpdateStock(EtatStock etatStock)
        {
            var data = await Ietat_stockServices.UpdateStock(etatStock);
            return Ok(data);
        }
    }
}

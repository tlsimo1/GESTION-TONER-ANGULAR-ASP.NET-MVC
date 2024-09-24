using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Container;
using webapi.Repos.Models;
using webapi.Services;

namespace webapi.Controllers
{
    //[Authorize]
    //[Route("api/[controller]")]
    //[ApiController]


    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices userService;
        public UserController(IUserServices userService)
        {
            this.userService = userService;
            
        }
        [AllowAnonymous]
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> Get()
        {
            var data = await userService.GetAllUsers();
            if(data==null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpGet("GetUserByReference")]
        public async Task<IActionResult> GetByReference(int Id)
        {
            var data = await userService.GetUserByReference(Id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(User _user)
        {
            var data = await userService.CreateUser(_user);
            return Ok(data);
        }
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(User user ,int Id)
        {
            var data = await userService.UpdateUser(user, Id);
            return Ok(data);
        }
        [HttpDelete("RemoveUser")]
        public async Task<IActionResult> RemoveUser(int Id)
        {
            var data = await userService.RemoveUser(Id);
            return Ok(data);
        }
    }
}

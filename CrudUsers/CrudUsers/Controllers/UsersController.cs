using CrudUsers.Context;
using CrudUsers.Entities;
using CrudUsers.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            return Ok(await userService.GetByIdUser(id));
        }
        [HttpPost("CreateUser")]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {
            return Ok(await userService.CreateUser(user));
        }
        [HttpGet("GetNameUser/{name}")]
        public async Task<ActionResult<User>> GetNameUser(string name)
        {
            return Ok(await userService.GetByNameUser(name));
        }
        [HttpDelete("DeleteUser/{id}")]
        public async Task<ActionResult<string>> DeleteUser(int id)
        {
            return Ok(await userService.DeleteUser(id));
        }
        [HttpGet("GetAllUser")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok(await userService.GetAllUser());
        }
        [HttpPut("UpdateUser")]
        public async Task<ActionResult<User>> UpdateUser([FromBody] User updateUser)
        {
            return Ok(await userService.UpdateUser(updateUser));
        }
    }
}

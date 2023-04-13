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
    }
}

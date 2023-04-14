using CrudUsers.Entities;
using CrudUsers.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;
        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }
        [HttpGet("GetAllRole")]
        public async Task<ActionResult<List<Role>>> GetAllRole()
        {
            return Ok(await roleService.GetAllRole());
        } 
        [HttpPost("CreateRole")]
        public async Task<ActionResult<Role>> AddRole([FromBody]Role role)
        {
            return Ok(await roleService.CreateRole(role));
        }
        [HttpPut("UpdateRole")]
        public async Task<ActionResult<Role>> UpdateRole(Role role)
        {
            return Ok(await roleService.UpdateRole(role));
        }
        [HttpGet("GetRoleById/{id}")]
        public async Task<ActionResult<Role>> GetRoleById(int id)
        {
            return Ok(await roleService.GetRoleById(id));
        }
        [HttpDelete("DeleteRole/{id}")]
        public async Task<ActionResult<string>> DeleteRole(int id)
        {
            return Ok(await roleService.DeleteRole(id));
        }
    }
}

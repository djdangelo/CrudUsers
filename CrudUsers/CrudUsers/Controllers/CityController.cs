using CrudUsers.Context;
using CrudUsers.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly DataBaseContext context;
        public CityController(DataBaseContext dataContext)
        {
            this.context = dataContext;
        }
        [HttpPost("CreateCity")]
        public async Task<ActionResult<List<City>>> CreateCity([FromBody]City city)
        {
            context.Cities.Add(city);
            await context.SaveChangesAsync();
            return Ok(await context.Cities.ToListAsync());
        }
        [HttpGet("GetAllCities")]
        public async Task<ActionResult<List<City>>> GetAllCities()
        {
            return Ok(await context.Cities.ToListAsync());
        }
        [HttpPut("UpdateCity/{id}")]
        public async Task<ActionResult<List<City>>> UpdateCity( [FromBody]City updateCity )
        {
            var city = await context.Cities.FindAsync(updateCity.Id);
            if (city == null)
            {
                return NotFound(new { message = "Ciudad no encontrada." });
            }
            city.Name = updateCity.Name;
            await context.SaveChangesAsync();
            return Ok(await context.Cities.ToListAsync());
        }
        [HttpGet("GetCityById/{id}")]
        public async Task<ActionResult<City>> GetCityById(int id)
        {
            var city = await context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound(new { message = "Ciudad no encontrada." });
            }
            return Ok(city);
        }
        [HttpDelete("DeleteCity/{id}")]
        public async Task<ActionResult<string>> DeleteCityById(int id)
        {
            var city = await context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound(new { message = "Ciudad no encontrada." });
            }
            context.Cities.Remove(city);
            await context.SaveChangesAsync();
            return Ok(new { message = "Ciudad eliminada correctamente." });
        }
    }
}

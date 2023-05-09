using CurdAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CurdAPI.Controllers
{
    [Route("api/demo")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApiDemoDbContext _apiDemoDbContext;
        public EmployeeController(ApiDemoDbContext apiDemoDbContext)        
        {
            _apiDemoDbContext = apiDemoDbContext;   

        }


        [HttpGet]
        [Route("get-user-list")]
        public async Task<IActionResult> GetAsync()
        {
            var users = await _apiDemoDbContext.Employees.ToListAsync();
            return Ok(users);
        }

        [HttpGet]
        [Route("get-user-by-id/{UserId}")]
        public async Task<IActionResult> GetUserByIdAsync(int UserId)
        {
            var users = await _apiDemoDbContext.Employees.FindAsync(UserId);
            return Ok(users);
        }

        [HttpPost]
        [Route("create-user")]
        
        public async Task<IActionResult> PostAsync(Employees user)
        {
            _apiDemoDbContext.Employees.Add(user);
            await _apiDemoDbContext.SaveChangesAsync();
            return Created($"/get-user-by-id/{user.EmployeeID}", user);
        }

        [HttpPut]
        [Route("update-user")]
        public async Task<IActionResult> PutAsync(Employees userToUpdate)
        {
            _apiDemoDbContext.Employees.Update(userToUpdate);
            await _apiDemoDbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        [Route("delete-user/{UserId}")]
        public async Task<IActionResult> DeleteAsync(int UserId)
        {
            var userToDelete = await _apiDemoDbContext.Employees.FindAsync(UserId);
            if(userToDelete == null)
            {
                return NotFound();
            }
            _apiDemoDbContext.Employees.Remove(userToDelete);
            await _apiDemoDbContext.SaveChangesAsync();
            return NoContent();
        }

    }
}

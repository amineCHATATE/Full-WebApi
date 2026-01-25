using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;
using WebApi.Services;

namespace WebApi.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class UsersHttpController(IUserService userService) : Controller
    {

        // GET: UsersController/GetUserById
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await userService.GetUserById(id);
            if (user is null )
            {
                return NotFound();
            }
            return Ok(user);
        }

        // GET: UsersController/GetAllUsers
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userService.GetAllUsers();
            if (!users.Any() )
            {
                return NotFound();
            }
            return Ok(users);
        }

        // POST: UsersController/Create
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(User user)
        {
            var result = await userService.CreateUser(user);
            if (result)
            {
                return CreatedAtAction(nameof(Create), new { id = user.Id }, user);
            }
            return BadRequest();
        }


        // POST: UsersController/Edit/5
        [HttpPost("[action]")]
        public async Task<IActionResult> Edit(User user)
        {
            var result = await userService.UpdateUser(user);
            if (result)
            {
                return CreatedAtAction(nameof(Create), new { id = user.Id }, user);
            }
            return BadRequest();
        }


        // POST: UsersController/Delete/5
        [HttpPost("[action]/{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await userService.DeleteUser(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}

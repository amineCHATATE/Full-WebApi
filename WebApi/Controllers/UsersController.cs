using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class UsersController(IUserInterface userRepository) : Controller
    {

        // GET: UsersController/GetUserById
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await userRepository.GetUserById(id);
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
            var users = await userRepository.GetAllUsers();
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
            var result = await userRepository.CreateUser(user);
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
            var result = await userRepository.UpdateUser(user);
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
            var result = await userRepository.DeleteUser(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}

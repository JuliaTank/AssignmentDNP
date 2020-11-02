using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssignmentWebAPI.Data;
using AssignmentWebAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace AssignmentWebAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class UsersController: ControllerBase
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IList<User>>> 
            GetUsers([FromQuery] string username, [FromQuery] string  password, [FromQuery] int id) {
            try {
                IList<User> users = await userService.GetUsersAsync();
                return Ok(users);
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] User user) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try {
                User added = await userService.AddUserAsync(user);
                return Created($"/{added.ID}",added); 
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
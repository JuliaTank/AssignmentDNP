using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssignmentWebAPI.Data;
using AssignmentWebAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace AssignmentWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController: ControllerBase
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

/*
!!!!!!!!!!!!!!! if there are two methods httpGet but one has FromQuery parameters im getting exception AmbiguousMatchException: The request matched multiple endpoints. Matches:

        AssignmentWebAPI.Controllers.UsersController.ValidateUserAsync (AssignmentWebAPI)
            AssignmentWebAPI.Controllers.UsersController.GetUsersAsync (AssignmentWebAPI)
        */
        [HttpGet]

        public async Task<ActionResult<User>> ValidateUserAsync([FromQuery] string username, [FromQuery] string  password)
        {
            try
            {
                User user = await userService.ValidateUserAsync(username, password);
                Console.WriteLine("valid data in the user controller "+username);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        /*[HttpGet]
        public async Task<ActionResult<IList<User>>> GetUsersAsync() {
            try {
                IList<User> users = await userService.GetUsersAsync();
                return Ok(users);
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }*/
        
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
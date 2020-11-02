using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssignmentWebAPI.Data;
using AssignmentWebAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace AssignmentWebAPI.Controllers
{
    [ApiController]
    [Route("[controller")]
    public class PeopleController : ControllerBase
    {
        private IPersonService personService;

        public PeopleController(IPersonService personService)
        {
            this.personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetPeople([FromQuery] int? userId, [FromQuery] string firstName,
            [FromQuery] string lastName)
        {
            try
            {
                IList<Adult> adults = await personService.GetPersonAsync();
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeletePerson([FromRoute] int id)
        {
            try
            {
                await personService.RemovePersonAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Adult>> AddPerson([FromBody] Adult person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Adult added = await personService.AddPersonAsync(person);
                return Created($"/{added.Id}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        [Route("{id:int")]
        public async Task<ActionResult<Adult>> UpdatePerson([FromBody] Adult person)
        {
            try
            {
                await personService.UpdateAsync(person);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
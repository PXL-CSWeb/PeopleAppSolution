using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleApp.Api.Services;
using PeopleApp.ClassLib.Models;

namespace PeopleApp.Api.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> ListPeople()
        {
            var people = await _peopleService.ListPeopleAsync();
            return Ok(people);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPersonById(long id)
        {
            var person = await _peopleService.GetPersonById(id);
            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<long>> AddPerson([FromBody] Person person)
        {
            await _peopleService.AddPersonAsync(person);
            return Ok(person.Id);
        }

        [HttpPut]
        public async Task<ActionResult<Person>> UpdatePerson([FromBody] Person person)
        {
            await _peopleService.UpdatePersonAsync(person);
            return Ok(person);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePerson(long id)
        {
            await _peopleService.DeletePersonAsync(id);
            return NoContent();
        }
    }
}

using PeopleApp.ClassLib.Models;

namespace PeopleApp.Api.Services
{
    public interface IPeopleService
    {
        Task<Person> AddPersonAsync(Person person);
        Task DeletePersonAsync(long id);
        Task<Person> GetPersonById(long id);
        Task<IEnumerable<Person>> ListPeopleAsync();
        Task<Person> UpdatePersonAsync(Person person);
    }
}
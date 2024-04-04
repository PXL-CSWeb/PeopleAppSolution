using Microsoft.EntityFrameworkCore;
using PeopleApp.Api.Data;
using PeopleApp.ClassLib.Models;

namespace PeopleApp.Api.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly DataContext _context;

        public PeopleService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> ListPeopleAsync()
        {
            return await _context.People
                //.Include(p => p.Department)
                //.Include(p => p.Location)
                .ToListAsync();
        }

        public async Task<Person> GetPersonById(long id)
        {
            return await _context.People.FindAsync(id);
        }

        public async Task<Person> AddPersonAsync(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<Person> UpdatePersonAsync(Person person)
        {
            _context.People.Update(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task DeletePersonAsync(long id)
        {
            var person = await _context.People.FindAsync(id);
            if (person is null)
                return;
            _context.People.Remove(person);
            await _context.SaveChangesAsync();
        }
    }
}

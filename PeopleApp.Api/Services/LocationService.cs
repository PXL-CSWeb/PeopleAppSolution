using Microsoft.EntityFrameworkCore;
using PeopleApp.Api.Data;
using PeopleApp.ClassLib.Models;

namespace PeopleApp.Api.Services
{
    public class LocationService : ILocationService
    {
        private readonly DataContext _dataContext;
        public LocationService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<Location>> ListLocationsAsync()
        {
            return await _dataContext.Locations.ToListAsync();
        }

        public async Task<Location?> GetLocationAsync(long id)
        {
            return await _dataContext.Locations.FindAsync(id);
        }

        public async Task<Location> AddLocationAsync(Location location)
        {
            _dataContext.Locations.Add(location);
            await _dataContext.SaveChangesAsync();

            return location;
        }

        public async Task<Location> UpdateLocationAsync(Location location)
        {
            _dataContext.Locations.Update(location);
            await _dataContext.SaveChangesAsync();

            return location;
        }

        public async Task DeleteLocationAsync(long id)
        {
            var location = await _dataContext.Locations.FindAsync(id);

            if (location is null)
                return;

            _dataContext.Locations.Remove(location);
            await _dataContext.SaveChangesAsync();
        }
    }
}

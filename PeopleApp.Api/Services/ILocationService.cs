using PeopleApp.ClassLib.Models;

namespace PeopleApp.Api.Services
{
    public interface ILocationService
    {
        Task<Location> AddLocationAsync(Location location);
        Task DeleteLocationAsync(long id);
        Task<Location?> GetLocationAsync(long id);
        Task<IEnumerable<Location>> ListLocationsAsync();
        Task<Location> UpdateLocationAsync(Location location);
    }
}
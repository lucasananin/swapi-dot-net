using Swapi.Models.Api;
using Swapi.Models.ViewModels;

namespace Swapi.Services.People;

public class PersonService(
    HttpClient httpClient,
    ILogger<PersonService> logger) : IPersonService
{
    public async Task<PersonDetailsViewModel?> GetByIdAsync(int id)
    {
        try
        {
            var person = await httpClient.GetFromJsonAsync<PersonApiModel>($"people/{id}");

            if (person is null)
            {
                logger.LogWarning("SWAPI returned null for Person {PersonId}", id);
                return null;
            }

            return new PersonDetailsViewModel
            {
                Name = person.Name,
                Height = person.Height,
                Mass = person.Mass,
                BirthYear = person.BirthYear,
                Gender = person.Gender
            };
        }
        catch (HttpRequestException ex)
        {
            logger.LogError(ex, "Unable to retrieve Person {PersonId} from SWAPI.", id);
            throw;
        }
    }
}
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;
        public CountryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CountryExist(int id)
        {
            return _context.Countries.Any(c=> c.Id == id);
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.OrderBy(e => e.Name).ToList();
        }

        public Country GetCountry(int id)
        {
           return _context.Countries.Where(e=>e.Id==id).FirstOrDefault();
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return _context.Owners.Where(e => e.Id == ownerId).Select(e=>e.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromACountry(int countryId)
        {
            return _context.Countries.Where(u => u.Id == countryId).Select(u => u.Owners).FirstOrDefault();
        }
    }
}

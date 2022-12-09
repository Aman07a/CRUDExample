using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
	public class CountriesService : ICountriesService
	{
		// Private field
		private readonly List<Country> _countries;

		// Constructor
		public CountriesService(bool initialize = true)
		{
			_countries = new List<Country>();

			if (initialize)
			{
				_countries.AddRange(new List<Country>() {
					new Country()
					{
						CountryID = Guid.Parse("44A936B5-2F43-4C46-8991-6C894D86CEED"),
						CountryName = "USA",
					},
					new Country()
					{
						CountryID = Guid.Parse("D7B616D2-E3A5-4800-8B6B-151E5F754B34"),
						CountryName = "Canada",
					},
					new Country()
					{
						CountryID = Guid.Parse("11D54130-73EF-4BF2-9ABA-FDA103A26A33"),
						CountryName = "UK",
					},
					new Country()
					{
						CountryID = Guid.Parse("2ADBD611-719C-4E32-A658-D81343E10AC7"),
						CountryName = "India",
					},
					new Country()
					{
						CountryID = Guid.Parse("E166E742-6771-48AC-A76A-21CF711EB753"),
						CountryName = "Australia",
					},
				});
			}
		}

		public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
		{
			// Validation: countryAddRequest parameter can't be null
			if (countryAddRequest == null)
			{
				throw new ArgumentNullException(nameof(countryAddRequest));
			}

			// Validation: CountryName can't be null
			if (countryAddRequest.CountryName == null)
			{
				throw new ArgumentException(nameof(countryAddRequest.CountryName));
			}

			// Validation: CountryName can't be duplicate
			if (_countries.Where(temp => temp.CountryName == countryAddRequest.CountryName).Count() > 0)
			{
				throw new ArgumentException("Given country name already exists");
			}

			// Convert object from CountryAddRequest to Country type
			Country country = countryAddRequest.ToCountry();

			// Generate CountryID
			country.CountryID = Guid.NewGuid();

			// Add country object into _countries
			_countries.Add(country);

			return country.ToCountryResponse();
		}

		public List<CountryResponse> GetAllCountries()
		{
			return _countries.Select(country => country.ToCountryResponse()).ToList();
		}

		public CountryResponse? GetCountryByCountryID(Guid? countryID)
		{
			if (countryID == null)
				return null;

			Country? country_response_from_list =
				_countries.FirstOrDefault(temp => temp.CountryID == countryID);

			if (country_response_from_list == null)
				return null;

			return country_response_from_list.ToCountryResponse();
		}
	}
}
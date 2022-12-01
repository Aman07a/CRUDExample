using System;
using Entities;
using ServiceContracts.DTO;
using ServiceContracts;
using System.ComponentModel.DataAnnotations;
using Services.Helpers;

namespace Services
{
	public class PersonsService : IPersonsService
	{
		// Private field
		private readonly List<Person> _persons;
		private readonly ICountriesService _countriesService;

		// Constructor
		public PersonsService()
		{
			_persons = new List<Person>();
			_countriesService = new CountriesService();
		}

		private PersonResponse ConvertPersonToPersonResponse(Person person)
		{
			PersonResponse personResponse = person.ToPersonResponse();
			personResponse.Country = _countriesService.GetCountryByCountryID(person.CountryID)?.CountryName;
			return personResponse;
		}

		public PersonResponse AddPerson(PersonAddRequest? personAddRequest)
		{
			// Check if PersonAddRequest is not null
			if (personAddRequest == null)
			{
				throw new ArgumentNullException(nameof(personAddRequest));
			}

			// Model validation
			ValidationHelper.ModelValidation(personAddRequest);

			// Convert personAddRequest into Person type
			Person person = personAddRequest.ToPerson();

			// Generate PersonID
			person.PersonID = Guid.NewGuid();

			// Add person object to persons list
			_persons.Add(person);

			// Convert the Person object into PersonResponse type
			return ConvertPersonToPersonResponse(person);
		}

		public List<PersonResponse> GetAllPersons()
		{
			throw new NotImplementedException();
		}

		public PersonResponse? GetPersonByPersonID(Guid? personID)
		{
			throw new NotImplementedException();
		}
	}
}

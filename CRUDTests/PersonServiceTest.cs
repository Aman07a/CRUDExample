using System;
using System.Collections.Generic;
using ServiceContracts;
using Entities;
using ServiceContracts.DTO;
using Services;
using ServiceContracts.Enums;

namespace CRUDTests
{
	public class PersonServiceTest
	{
		// Private field
		private readonly IPersonsService _personService;

		// Constructor
		public PersonServiceTest()
		{
			_personService = new PersonsService();
		}

		#region Add Person

		// When we supply null value as PersonAddRequest, it should throw ArgumentNullException
		[Fact]
		public void AddPerson_NullPerson()
		{
			// Arrange
			PersonAddRequest? personAddRequest = null;

			// Act
			Assert.Throws<ArgumentException>(() =>
			{
				personAddRequest = new PersonAddRequest();
			});
		}

		// When we supply null value as PersonName, it should throw ArgumentException
		[Fact]
		public void AddPerson_PersonNameIsNull()
		{
			// Arrange
			PersonAddRequest? personAddRequest = new PersonAddRequest() { PersonName = null };

			// Act
			Assert.Throws<ArgumentException>(() =>
			{
				_personService.AddPerson(personAddRequest);
			});
		}

		// When we supply null value as PersonAddRequest,
		// it should insert the person into the persons list
		// And it should return an object of PersonResponse,
		// which includes with the newly generated perosn id
		[Fact]
		public void AddPerson_ProperPersonDetails()
		{
			//Arrange
			PersonAddRequest? personAddRequest = new PersonAddRequest()
			{
				PersonName = "Person name...",
				Email = "person@example.com",
				Address = "sample address",
				CountryID = Guid.NewGuid(),
				Gender = GenderOptions.Male,
				DateOfBirth = DateTime.Parse("2000-01-01"),
				ReceiveNewsLetters = true
			};

			// Act
			PersonResponse person_response_from_add = 
				_personService.AddPerson(personAddRequest);

			List<PersonResponse> persons_list = 
				_personService.GetAllPersons();

			// Assert
			Assert.True(person_response_from_add.PersonID != Guid.Empty);

			Assert.Contains(person_response_from_add, persons_list);
		}

		#endregion
	}
}

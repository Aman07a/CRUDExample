﻿using Entities;
using ServiceContracts.Enums;
using System;
using System.Net;
using System.Reflection;

namespace ServiceContracts.DTO
{
	/// <summary>
	/// Represents DTO class that is used as return type of most methods of Persons Service
	/// </summary>
	public class PersonResponse
	{
		public Guid PersonID { get; set; }
		public string? PersonName { get; set; }
		public string? Email { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string? Gender { get; set; }
		public Guid? CountryID { get; set; }
		public string? Country { get; set; }
		public string? Address { get; set; }
		public bool ReceiveNewsLetters { get; set; }
		public double? Age { get; set; }

		/// <summary>
		/// Compares the current object data with the parameter object
		/// </summary>
		/// <param name="obj">The PersonReponse Object to compare</param>
		/// <returns>True or false, indicating whether all person details are matched with the specified parameter object</returns>
		public override bool Equals(object? obj)
		{
			if (obj == null) return false;

			if (obj.GetType() != typeof(PersonResponse)) return false;

			PersonResponse person = (PersonResponse)obj;

			return PersonID == person.PersonID &&
				PersonName == person.PersonName &&
				DateOfBirth == person.DateOfBirth &&
				Gender == person.Gender &&
				Country == person.Country &&
				Address == person.Address &&
				ReceiveNewsLetters == person.ReceiveNewsLetters &&
				Age == person.Age;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}

	public static class PersonExtensions
	{
		/// <summary>
		/// An extension method to convert an object of Person class into PersonResponse class
		/// </summary>
		/// <param name="person">The Person object to convert</param>
		/// /// <returns>Returns the converted PersonResponse object</returns>
		public static PersonResponse ToPersonResponse(this Person person)
		{
			return new PersonResponse()
			{
				PersonID = person.PersonID,
				PersonName = person.PersonName,
				DateOfBirth = person.DateOfBirth,
				ReceiveNewsLetters = person.ReceiveNewsLetters,
				Address = person.Address,
				CountryID = person.CountryID,
				Gender = person.Gender,
				Age = (person.DateOfBirth != null) ? Math.Round((DateTime.Now - person.DateOfBirth.Value).TotalDays / 365.25) : null
			};
		}
	}
}
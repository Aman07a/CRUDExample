using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
	/// <summary>
	/// Person domain model class
	/// </summary>
	public class Person
	{
		[Key]
		public Guid PersonID { get; set; }

		// Nvarchar(40)
		[StringLength(40)]
		// [Required]
		public string? PersonName { get; set; }

        // Nvarchar(40)
        [StringLength(40)]
        public string? Email { get; set; }

		public DateTime? DateOfBirth { get; set; }

        // Nvarchar(10)
        [StringLength(10)]
        public string? Gender { get; set; }

		// UniqueIdentifier
		public Guid? CountryID { get; set; }

        // Nvarchar(200)
        [StringLength(200)]
        public string? Address { get; set; }

		// Bit
		public bool ReceiveNewsLetters { get; set; }

		// [Column("TaxIdentificationNumber", TypeName = "varchar(8)")]
		public string? TIN { get; set; }
	}
}

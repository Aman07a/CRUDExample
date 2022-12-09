using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;

namespace CRUDExample.Controllers
{
	public class PersonsController : Controller
	{
		// Private fields
		private readonly IPersonsService _personsService;

		// Constructor
		public PersonsController(IPersonsService personsService)
		{
			_personsService = personsService;
		}

		[Route("persons/index")]
		[Route("/")]
		public IActionResult Index()
		{
			List<PersonResponse> persons = _personsService.GetAllPersons();

			// Views/Persons/Index.cshtml
			return View(persons);
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CheeseMVC.Controllers
{
	public class CheeseController : Controller
	{
		static private List<string> Cheeses = new List<string>();
		public IActionResult Index()
		{
			ViewBag.cheeses = Cheeses;

			return View();
		}

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		[Route("/Cheese/Add")]
		public IActionResult NewCheese(string name)
		{
			if(name == null || name == "" || name == " ")
			{
				//Don't let the user enter nothing into the list
				return View("Add");
			}
		
			if (name == "1" || name == "2")
			{
				//Don't let the user enter a number into the list
				return View("Add");
			}
			else
			{
				//Add what the user input to the form to the list then show them the list on the other page
				Cheeses.Add(name);
				return Redirect("/Cheese");
			}
		}

		public IActionResult Remove()
		{
			ViewBag.cheeses = Cheeses;
			return View();
		}

		[HttpPost]
		[Route("/Cheese/Remove")]
		public IActionResult RemoveCheese(string name)
		{
			Cheeses.Remove(name);
			return Redirect("/Cheese");
		}
	}
}

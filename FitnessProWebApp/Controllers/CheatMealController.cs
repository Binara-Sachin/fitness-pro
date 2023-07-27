using FitnessProWebApp.Models;
using FitnessProWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessProWebApp.Controllers
{
    public class CheatMealController : Controller
    {
		private IAPIClientService<CheatMeal> _iAPIClientService;
		private readonly string _subURL = "CheatMeal";
		private readonly string _subURLwithSlash = "CheatMeal/";

		public CheatMealController(IAPIClientService<CheatMeal> iAPIClientService)
		{
			_iAPIClientService = iAPIClientService;
		}

		public async Task<IActionResult> Index()
		{
			var cheatMeals = await _iAPIClientService.GetAll(_subURL);
			return View(cheatMeals);
		}

		public async Task<IActionResult> Details(Int64 id)
		{
			var cheatMeal = await _iAPIClientService.GetById(id, _subURLwithSlash);
			return View(cheatMeal);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CheatMeal cheatMeal)
		{
			if (ModelState.IsValid)
			{
				var resut = await _iAPIClientService.Add(cheatMeal, _subURL);
				TempData["success"] = "Cheat Meal added successfully";
				return RedirectToAction(nameof(Index));
			}
			return View(cheatMeal);
		}

		public async Task<IActionResult> Edit(Int64 id)
		{
			var cheatMeal = await _iAPIClientService.GetById(id, _subURLwithSlash);
			return View(cheatMeal);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(CheatMeal cheatMeal)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var resut = await _iAPIClientService.Update(cheatMeal, _subURL);
				}
				catch (Exception ex)
				{
					TempData["error"] = "Error when editing Cheat Meal data";
					throw ex;
				}
				TempData["success"] = "Cheat Meal data edited successfully";
				return RedirectToAction(nameof(Index));
			}
			return View(cheatMeal);
		}
		public async Task<IActionResult> Delete(Int64 id)
		{
			var cheatMeal = await _iAPIClientService.GetById(id, _subURLwithSlash);
			return View(cheatMeal);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(CheatMeal cheatMeal)
		{
			var resut = await _iAPIClientService.Delete(cheatMeal.CheatMealId, _subURLwithSlash);
			TempData["success"] = "Cheat Meal data deleted successfully";
			return RedirectToAction(nameof(Index));
		}
	}
}

using FitnessProWebApp.Models;
using FitnessProWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessProWebApp.Controllers
{
    public class WorkoutController : Controller
    {
        private IAPIClientService<Workout> _iAPIClientService;
		private readonly string _subURL = "Workout";
		private readonly string _subURLwithSlash = "Workout/";

		public WorkoutController(IAPIClientService<Workout> iAPIClientService)
        {
            _iAPIClientService = iAPIClientService;
        }

        public async Task<IActionResult> Index()
        {
            var workouts = await _iAPIClientService.GetAll(_subURL);
            return View(workouts);
        }

        public async Task<IActionResult> Details(Int64 id)
        {
            var workout = await _iAPIClientService.GetById(id, _subURLwithSlash);
            return View(workout);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Workout workout)
        {
            if (ModelState.IsValid)
            {
                workout.CalculateCaloryBurn();
                var resut = await _iAPIClientService.Add(workout, _subURL);
				TempData["success"] = "Workout added successfully";
				return RedirectToAction(nameof(Index));
            }
            return View(workout);
        }

        public async Task<IActionResult> Edit(Int64 id)
        {
            var workout = await _iAPIClientService.GetById(id, _subURLwithSlash);
            return View(workout);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Workout workout)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    workout.CalculateCaloryBurn();
                    var resut = await _iAPIClientService.Update(workout, _subURL);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
				TempData["success"] = "Workout edited successfully";
				return RedirectToAction(nameof(Index));
            }
            return View(workout);
        }
        public async Task<IActionResult> Delete(Int64 id)
        {
            var workout = await _iAPIClientService.GetById(id, _subURLwithSlash);
            return View(workout);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(Workout workout)
		{
            var resut = await _iAPIClientService.Delete(workout.WorkoutId, _subURLwithSlash);
			TempData["success"] = "Workout deleted successfully";
			return RedirectToAction(nameof(Index));
        }
    }
}

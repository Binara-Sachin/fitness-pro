using FitnessProWebApp.Models;
using FitnessProWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace FitnessProWebApp.Controllers
{
    public class ReportController : Controller
    {
        private IAPIClientService<CheatMeal> _iAPIClientServiceCheatMeal;
        private IAPIClientService<Workout> _iAPIClientServiceWorkout;

        public ReportController(IAPIClientService<CheatMeal> iAPIClientServiceCheatMeal, IAPIClientService<Workout> iAPIClientServiceWorkout)
        {
            _iAPIClientServiceCheatMeal = iAPIClientServiceCheatMeal;
            _iAPIClientServiceWorkout = iAPIClientServiceWorkout;
        }

        public IActionResult Generate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Generate(Report report)
        {
            try
            {
                var cheatMeals = await _iAPIClientServiceCheatMeal.GetAll("CheatMeal");
                var filteredCheatMeals = cheatMeals.Where(i => i.CreatedDate.Date >= report.StartDate && i.CreatedDate.Date <= report.EndDate).ToList();

                var workouts = await _iAPIClientServiceWorkout.GetAll("Workout");
                var filteredWorkouts = workouts.Where(i => i.CreatedDate.Date >= report.StartDate && i.CreatedDate.Date <= report.EndDate).ToList();

                int caloriesBurned = 0;

                foreach (Workout e in filteredWorkouts)
                {
                    caloriesBurned += e.CaloriesBurned;
                }

                int caloriesGained = 0;

                foreach (CheatMeal e in filteredCheatMeals)
                {
                    caloriesGained += e.CaloriesGained;
                }

                int netCaloryBurn = caloriesBurned - caloriesGained;
                int weightDiff = (int)(netCaloryBurn * 0.45 * 1000 / 3500);

                report.data.Add("Number Of Workouts: ", filteredWorkouts.Count);
                report.data.Add("Number Of Cheat Meals: ", filteredCheatMeals.Count);
                report.data.Add("Total Calories Burned: ", caloriesBurned);
                report.data.Add("Total Calories Gained: ", caloriesGained);
                report.data.Add("Net Calories Burned(+)/Gained(-): ", netCaloryBurn);
                report.data.Add("Net Weight Loss(+)/Gain(-) in grams (g): ", weightDiff);

                report.generationComplete = true;

                TempData["success"] = "Report generated successfully";
                return View(report);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error occoured while generating the report";
                return View();
            }

            
        }
    }
}

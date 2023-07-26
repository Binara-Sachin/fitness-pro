using Microsoft.AspNetCore.Mvc;
using CheatMealAPI.Models;
using CheatMealAPI.Services;

namespace CheatMealAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheatMealController : Controller
    {
        private readonly ICheatMealService cheatMealService;
            
        public CheatMealController(ICheatMealService _cheatMealService)
        {
            cheatMealService = _cheatMealService;
        }
            
        [HttpGet]
        public IEnumerable<CheatMeal> CheatMealList()
        {
            var cheatMealList = cheatMealService.GetCheatMealList(0);
            return cheatMealList;
        }
            
        [HttpGet("{id}")]
        public CheatMeal GetCheatMealById(int id)
        {
            return cheatMealService.GetCheatMealById(id);
        }
            
        [HttpPost]
        public CheatMeal AddCheatMeal(CheatMeal cheatMeal)
        {
            return cheatMealService.AddCheatMeal(cheatMeal);
        }
            
        [HttpPut]
        public CheatMeal UpdateCheatMeal(CheatMeal cheatMeal)
        {
            return cheatMealService.UpdateCheatMeal(cheatMeal);
        }
            
        [HttpDelete("{id}")]
        public bool DeleteCheatMeal(int id)
        {
            return cheatMealService.DeleteCheatMeal(id);
        }
    }

}

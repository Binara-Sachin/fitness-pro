using CheatMealAPI.Models;

namespace CheatMealAPI.Services
{
    public interface ICheatMealService
    {
        public IEnumerable<CheatMeal> GetCheatMealList(int UserId);
        public CheatMeal GetCheatMealById(int id);
        public CheatMeal AddCheatMeal(CheatMeal cheatMeal);
        public CheatMeal UpdateCheatMeal(CheatMeal cheatMeal);
        public bool DeleteCheatMeal(int Id);
    }
}

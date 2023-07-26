using CheatMealAPI.Data;
using CheatMealAPI.Models;

namespace CheatMealAPI.Services
{
    public class CheatMealService : ICheatMealService
    {
        private readonly ApplicationDbContext _dbContext;

        public CheatMealService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CheatMeal AddCheatMeal(CheatMeal cheatMeal)
        {
            var result = _dbContext.CheatMeals.Add(cheatMeal);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public bool DeleteCheatMeal(int Id)
        {
            var filteredData = _dbContext.CheatMeals.Where(x => x.CheatMealId == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }

        public IEnumerable<CheatMeal> GetCheatMealList(int UserId)
        {
           return _dbContext.CheatMeals.ToList();
        }

        public CheatMeal GetCheatMealById(int id)
        {
            return _dbContext.CheatMeals.Where(x => x.CheatMealId == id).FirstOrDefault();
        }

        public CheatMeal UpdateCheatMeal(CheatMeal cheatMeal)
        {
            var result = _dbContext.CheatMeals.Update(cheatMeal);
            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}

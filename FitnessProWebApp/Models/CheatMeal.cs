using System.ComponentModel.DataAnnotations;

namespace FitnessProWebApp.Models
{
    public class CheatMeal
    {
        public readonly Dictionary<string, int> caloriesPer100g = new Dictionary<string, int>(){
            {"Pizza", 266},
            {"Burger", 295},
            {"Hot Dog", 290},
            {"Milkshake", 112},
            {"Chocolate", 546},
        };

        [Key]
        public int CheatMealId { get; set; }
        public int UserId { get; set; }
        public string CheatMealName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Amount { get; set; }
        public int CaloriesGained { get; set; }

        public void CalculateCaloryGain()
        {
            this.CaloriesGained = caloriesPer100g[this.CheatMealName] * this.Amount / 100;
        }
    }
}

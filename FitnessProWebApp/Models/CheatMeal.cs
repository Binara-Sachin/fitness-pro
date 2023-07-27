using System.ComponentModel.DataAnnotations;

namespace FitnessProWebApp.Models
{
    public class CheatMeal
    {
        [Key]
        public int CheatMealId { get; set; }
        public int UserId { get; set; }
        public string CheatMealName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Amount { get; set; }
        public int CaloriesGained { get; set; }
    }
}

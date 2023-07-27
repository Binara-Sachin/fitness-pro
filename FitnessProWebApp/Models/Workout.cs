using System.ComponentModel.DataAnnotations;

namespace FitnessProWebApp.Models
{
    public class Workout
    {
        public readonly Dictionary<string, int> caloriesBurnedPerHour = new Dictionary<string, int>(){
            {"Running", 800},
            {"Cycling", 600},
            {"Swimming", 500},
            {"PushUps", 550},
            {"Weight Lifting", 700},
            {"Squats", 550},
        };

        [Key]
        public int WorkoutId { get; set; }
        public int UserId { get; set; }
        public string WorkoutName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int WorkoutDuration { get; set; }
        public int CaloriesBurned { get; set; }

        public void CalculateCaloryBurn()
        {
            this.CaloriesBurned = caloriesBurnedPerHour[this.WorkoutName] * this.WorkoutDuration / 60;
        }
    }
}

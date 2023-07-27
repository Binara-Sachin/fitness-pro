using System.ComponentModel.DataAnnotations;

namespace FitnessProWebApp.Models
{
    public class Workout
    {
        [Key]
        public int WorkoutId { get; set; }
        public int UserId { get; set; }
        public string WorkoutName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int WorkoutDuration { get; set; }
        public int CaloriesBurned { get; set; }
    }
}

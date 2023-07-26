using WorkoutAPI.Models;

namespace WorkoutAPI.Services
{
    public interface IWorkoutService
    {
        public IEnumerable<Workout> GetWorkoutList(int UserId);
        public Workout GetWorkoutById(int id);
        public Workout AddWorkout(Workout workout);
        public Workout UpdateWorkout(Workout workout);
        public bool DeleteWorkout(int Id);
    }
}

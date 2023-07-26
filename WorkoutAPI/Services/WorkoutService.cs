using WorkoutAPI.Data;
using WorkoutAPI.Models;

namespace WorkoutAPI.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly ApplicationDbContext _dbContext;

        public WorkoutService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Workout AddWorkout(Workout workout)
        {
            var result = _dbContext.Workouts.Add(workout);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public bool DeleteWorkout(int Id)
        {
            var filteredData = _dbContext.Workouts.Where(x => x.WorkoutId == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }

        public IEnumerable<Workout> GetWorkoutList(int UserId)
        {
           return _dbContext.Workouts.ToList();
        }

        public Workout GetWorkoutById(int id)
        {
            return _dbContext.Workouts.Where(x => x.WorkoutId == id).FirstOrDefault();
        }

        public Workout UpdateWorkout(Workout workout)
        {
            var result = _dbContext.Workouts.Update(workout);
            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}

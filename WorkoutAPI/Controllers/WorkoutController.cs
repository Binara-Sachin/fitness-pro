using Microsoft.AspNetCore.Mvc;
using WorkoutAPI.Models;
using WorkoutAPI.Services;

namespace WorkoutAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : Controller
    {
        private readonly IWorkoutService workoutService;
            
        public WorkoutController(IWorkoutService _workoutService)
        {
            workoutService = _workoutService;
        }
            
        [HttpGet]
        public IEnumerable<Workout> WorkoutList()
        {
            var workoutList = workoutService.GetWorkoutList(0);
            return workoutList;
        }
            
        [HttpGet("{id}")]
        public Workout GetWorkoutById(int id)
        {
            return workoutService.GetWorkoutById(id);
        }
            
        [HttpPost]
        public Workout AddWorkout(Workout workout)
        {
            return workoutService.AddWorkout(workout);
        }
            
        [HttpPut]
        public Workout UpdateWorkout(Workout workout)
        {
            return workoutService.UpdateWorkout(workout);
        }
            
        [HttpDelete("{id}")]
        public bool DeleteWorkout(int id)
        {
            return workoutService.DeleteWorkout(id);
        }
    }

}

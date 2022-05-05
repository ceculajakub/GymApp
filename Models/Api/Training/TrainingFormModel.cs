using GymApp.Models.Api.ExercisesDone;
using System.Collections.Generic;
namespace GymApp.Models.Api.Training
{
    public class TrainingFormModel
    {
        public int TrainingPlanId { get; set; }
        public string Attention { get; set; }
        public double AvgPulse { get; set; }
        
        public List<ExerciseDoneFormModel> ExercisesDone { get; set; }
    }
}

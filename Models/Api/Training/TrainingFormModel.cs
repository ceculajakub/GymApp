using GymApp.Models.Api.ExercisesDone;
using System.Collections.Generic;
namespace GymApp.Models.Api.Training
{
    public class TrainingFormModel
    {
        public long TrainingPlanId { get; set; }
        public string Attention { get; set; }
        public List<ExerciseDoneFormModel> ExercisesDone { get; set; }
    }
}

using System.Collections.Generic;

namespace GymApp.Models.Api.TrainingPlan
{
    public class TrainingPlanFormModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public List<int> ExerciseId { get; set; }
    }
}

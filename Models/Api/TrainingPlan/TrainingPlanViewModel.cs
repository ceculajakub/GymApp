using GymApp.Models.Api.Exercise;
using System.Collections.Generic;

namespace GymApp.Models.Api.TrainingPlan
{
    public class TrainingPlanViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }
        public List<ExcerciseFormModel> Exercises { get; set; }
    }
}

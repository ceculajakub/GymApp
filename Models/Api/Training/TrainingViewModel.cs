using GymApp.Models.DataBase;
using System;
using System.Collections.Generic;

namespace GymApp.Models.Api.Training
{
    public class TrainingViewModel
    {
        public long Id { get; set; }
        public long TrainingPlanId { get; set; }
        public long UserId { get; set; }
        public string Attention { get; set; }
        public DateTime ExecutionTime { get; set; }
        public List<ExerciseDone> ExercisesDone { get; set; }
    }
}

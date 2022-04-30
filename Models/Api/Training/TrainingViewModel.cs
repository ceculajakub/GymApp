using GymApp.Models.Api.ExerciseDone;
using GymApp.Models.DataBase;
using System;
using System.Collections.Generic;

namespace GymApp.Models.Api.Training
{
    public class TrainingViewModel
    {
        public int Id { get; set; }
        public int TrainingPlanId { get; set; }
        public int UserId { get; set; }
        public DateTime ExecutionTime { get; set; }
        public string Attention { get; set; }
        public float AvgPulse { get; set; }
        
        

        public List<ExerciseDoneViewModel> ExercisesDone { get; set; }
    }
}

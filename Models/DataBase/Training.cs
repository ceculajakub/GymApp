using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymApp.Models.DataBase
{
    public class Training
    {
        public Training()
        {
            ExercisesDone = new HashSet<ExerciseDone>();
        }

        [Key]
        public int Id { get; set; }
        public int TrainingPlanId { get; set; }
        public int UserId { get; set; }
        public DateTime ExecutionTime { get; set; }
        public string Attention { get; set; }

        public TrainingPlan TrainingPlan { get; set; }
        public ICollection<ExerciseDone> ExercisesDone { get; set; }
    }
}

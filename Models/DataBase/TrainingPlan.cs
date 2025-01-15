using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymApp.Models.DataBase
{
    public class TrainingPlan
    {
        public TrainingPlan()
        {
            TrainingPlanExercises = new HashSet<TrainingPlanExercise>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<TrainingPlanExercise> TrainingPlanExercises { get; set; }
        public ICollection<Training> Trainings { get; set; }
    }
}

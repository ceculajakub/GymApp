using System.ComponentModel.DataAnnotations;


namespace GymApp.Models.DataBase
{
    public class TrainingPlanExercise
    {
        [Key]
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public int ExerciseId { get; set; }

        public TrainingPlan TrainingPlan { get; set; }
        public Exercise Exercise { get; set; }
    }
}

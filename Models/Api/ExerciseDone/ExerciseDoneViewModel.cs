namespace GymApp.Models.Api.ExerciseDone
{
    public class ExerciseDoneViewModel
    {
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public int ExerciseId  { get; set; }
        public int Reps { get; set; }
        public double Weight  { get; set; }
        public string Equipment { get; set; }
        public int Pulse { get; set; }

    }
}

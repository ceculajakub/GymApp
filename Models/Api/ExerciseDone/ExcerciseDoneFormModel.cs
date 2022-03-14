namespace GymApp.Models.Api.ExercisesDone
{
    public class ExcerciseDoneFormModel
    {
        public long ExerciseId { get; set; }
        public long Reps { get; set; }
        public long Weight { get; set; }
        public string Equipment { get; set; }
    }
}

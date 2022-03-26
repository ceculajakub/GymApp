using GymApp.Enums;

namespace GymApp.Models.Api.Exercise
{
    public class ExerciseFormModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ExerciseType Type { get; set; }
    }
}

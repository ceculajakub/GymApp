﻿namespace GymApp.Models.Api.ExercisesDone
{
    public class ExerciseDoneFormModel
    {
        public int ExerciseId { get; set; }
        public int Reps { get; set; }
        public double Weight { get; set; }
        public string Equipment { get; set; }
        public int Pulse { get; set; }
    }
}

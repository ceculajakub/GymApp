﻿using GymApp.Models.Api.Exercise;
using System.Collections.Generic;

namespace GymApp.Models.Api.TrainingPlan
{
    public class TrainingPlanViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public List<ExerciseFormModel> Exercises { get; set; }
    }
}

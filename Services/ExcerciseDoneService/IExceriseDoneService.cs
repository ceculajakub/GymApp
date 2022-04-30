using GymApp.Models.Api.ExercisesDone;
using System.Collections.Generic;

namespace GymApp.Services.ExerciseDoneService
{
    public interface IExerciseDoneService
    {
        void Create(List<ExerciseDoneFormModel> Exercises, int trainingId);
    }
}

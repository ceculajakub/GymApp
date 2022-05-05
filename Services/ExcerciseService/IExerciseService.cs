using GymApp.Models.Api.Exercise;
using GymApp.Models.DataBase;
using System.Collections.Generic;

namespace GymApp.Services.ExerciseService
{
    public interface IExerciseService
    {
        Exercise Create(ExerciseFormModel model);
        List<ExerciseFormModel> GetList();
        ExerciseFormModel Fetch(int id);
        void Delete(int exerciseId);
    }
}

using GymApp.Models.Api.Exercise;
using GymApp.Models.DataBase;
using System.Collections.Generic;

namespace GymApp.Services.ExcerciseService
{
    public interface IExerciseService
    {
        Exercise Create(ExcerciseFormModel model);
        List<ExcerciseFormModel> GetList();
        ExcerciseFormModel Fetch(long id);
    }
}

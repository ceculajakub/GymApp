using GymApp.Models.Api.ExercisesDone;
using System.Collections.Generic;

namespace GymApp.Services.ExcerciseDoneService
{
    public interface IExceriseDoneService
    {
        void Create(List<ExcerciseDoneFormModel> excercises, long trainingId);
    }
}

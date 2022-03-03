using GymApp.Models.Api.Training;
using GymApp.Models.DataBase;
using System.Collections.Generic;

namespace GymApp.Services.TrainingService
{
    public interface ITrainingService
    {
        Training Create(TrainingFormModel model);
        List<TrainingViewModel> GetList(long userId);
        TrainingViewModel Fetch(long trainingId);
        Training Update(TrainingFormModel model, long trainingId);
        void Delete(long trainingId);
    }
}

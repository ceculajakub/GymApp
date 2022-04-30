using GymApp.Models.Api.Training;
using GymApp.Models.DataBase;
using System.Collections.Generic;

namespace GymApp.Services.TrainingService
{
    public interface ITrainingService
    {
        Training Create(TrainingFormModel model);
        
        TrainingViewModel Fetch(int trainingId);
        Training Update(TrainingFormModel model, int trainingId);
        void Delete(int trainingId);
    }
}

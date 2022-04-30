using GymApp.Models.Api.TrainingPlan;
using GymApp.Models.DataBase;

namespace GymApp.Services.TrainingPlanService
{
    public interface ITrainingPlanService
    {
        TrainingPlan Create(TrainingPlanFormModel model);
    }
}

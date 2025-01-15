using AutoMapper;
using GymApp.Data.Repositories;
using GymApp.Models.Api.TrainingPlan;
using GymApp.Models.DataBase;

namespace GymApp.Services.TrainingPlanService
{
    public class TrainingPlanService : ITrainingPlanService
    {
        private ITrainingPlanRepository _trainingPlanRepository { get; }
        private IMapper _mapper { get; }

        public TrainingPlanService(ITrainingPlanRepository trainingPlanRepository, IMapper mapper)
        {
            _trainingPlanRepository = trainingPlanRepository;
            _mapper = mapper;
        }

        public TrainingPlan Create(TrainingPlanFormModel model)
        {
            var entity = _mapper.Map<TrainingPlan>(model);

            _trainingPlanRepository.Add(entity);

            return entity;
        }
    }
}
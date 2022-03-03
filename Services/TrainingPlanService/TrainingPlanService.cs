using AutoMapper;
using GymApp.Data;
using GymApp.Models.Api.TrainingPlan;
using GymApp.Models.DataBase;

namespace GymApp.Services.TrainingPlanService
{
    public class TrainingPlanService : ITrainingPlanService
    {
        private DataContext _context { get; }
        private IMapper _mapper { get; }

        public TrainingPlanService(DataContext _context, IMapper mapper)
        {
            this._context = _context;
            _mapper = mapper;
        }

        public TrainingPlan Create(TrainingPlanFormModel model)
        {
            var entity = _mapper.Map<TrainingPlan>(model);

            _context.Add<TrainingPlan>(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}

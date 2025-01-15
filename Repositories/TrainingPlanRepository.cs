using GymApp.Models.DataBase;

namespace GymApp.Data.Repositories
{
    public class TrainingPlanRepository : ITrainingPlanRepository
    {
        private readonly DataContext _context;

        public TrainingPlanRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(TrainingPlan entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }
    }

    public interface ITrainingPlanRepository
    {
        void Add(TrainingPlan entity);
    }
}

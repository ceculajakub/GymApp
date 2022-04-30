using AutoMapper;
using GymApp.Data;
using GymApp.Models.Api.ExercisesDone;
using GymApp.Models.DataBase;
using GymApp.Services.TrainingService;
using System.Collections.Generic;

namespace GymApp.Services.ExerciseDoneService
{
    public class ExerciseDoneService : IExerciseDoneService
    {
        private readonly DataContext _context;
        private IMapper _mapper { get; }
        public ExerciseDoneService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(List<ExerciseDoneFormModel> Exercises, int trainingId)
        {
            foreach(var exercise in Exercises)
            {
                var entity = _mapper.Map<ExerciseDone>(exercise);
                entity.TrainingId = trainingId;

                _context.Add<ExerciseDone>(entity);
            }
            _context.SaveChanges();
        }
    }
}

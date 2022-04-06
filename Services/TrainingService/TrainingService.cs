using AutoMapper;
using GymApp.Data;
using GymApp.Models.Api.Training;
using GymApp.Models.DataBase;
using GymApp.Services.ExerciseDoneService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GymApp.Services.TrainingService
{
    public class TrainingService : ITrainingService
    {
        private readonly DataContext _context;
        private IMapper _mapper { get; }
        private IExerciseDoneService _exerciseDoneService { get; set; }
        public TrainingService(DataContext context, IMapper mapper, IExerciseDoneService exerciseDoneService)
        {
            _context = context;
            _mapper = mapper;
            _exerciseDoneService = exerciseDoneService;
        }

        public Training Create(TrainingFormModel model)
        {
            var training = _mapper.Map<Training>(model);
            training.ExecutionTime = DateTime.Now;

            training.UserId = _context.TrainingPlans
                                .Where(p => p.Id == training.TrainingPlanId)
                                .Select(p => p.UserId)
                                .FirstOrDefault();

            _context.Add<Training>(training);
            _context.SaveChanges();

            if (model.ExercisesDone != null)
                _exerciseDoneService.Create(model.ExercisesDone, training.Id);

            return training;
        }

        

        public TrainingViewModel Fetch(long trainingId)
        {
            var entity = _context.Trainings
                                .Where(p => p.Id == trainingId)
                                .Include(p => p.ExercisesDone)
                                .FirstOrDefault();

            return _mapper.Map<TrainingViewModel>(entity);
        }

        public Training Update(TrainingFormModel model, long trainingId)
        {
            var entity = _context.Trainings
                                .Where(p => p.Id == trainingId)
                                .Include(p => p.ExercisesDone)
                                .FirstOrDefault();

            var result = _mapper.Map<TrainingFormModel, Training>(model, entity);

            _context.Update<Training>(result);
            _context.SaveChanges();

            return result;
        }

        public void Delete(long trainingId)
        {
            var entity = _context.Trainings
                                .Where(p => p.Id == trainingId)
                                .Include(p => p.ExercisesDone)
                                .FirstOrDefault();

            _context.Remove<Training>(entity);
            _context.SaveChanges();
        }
    }
}

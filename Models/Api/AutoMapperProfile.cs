using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace GymApp.Models.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() : this("")
        {
        }

        protected AutoMapperProfile(string profileName) : base(profileName)
        {
            UserMap();
            TrainingMap();
            ExerciseDoneMap();
            TrainingPlanMap();
            ExerciseMap();
            UserMeasurementsMap();
        }

        protected void UserMap()
        {
            CreateMap<Models.Api.User.UserViewModel, Models.DataBase.User>()
                .ForMember(p => p.PasswordHash, o => o.Ignore())
                .ForMember(p => p.PasswordSalt, o => o.Ignore());

            CreateMap<Models.Api.User.UserFormModel, Models.DataBase.User>()
                .ForMember(p => p.PasswordHash, o => o.Ignore())
                .ForMember(p => p.PasswordSalt, o => o.Ignore())
                .ForMember(p => p.UserGoals, o => o.Ignore())
                .ForMember(p => p.UserMeasurements, o => o.Ignore())
                .ForMember(p => p.TrainingPlans, o => o.Ignore());

            CreateMap<Models.DataBase.User, Models.Api.User.UserFormModel>()
                .ForMember(p => p.Password, o => o.Ignore());


            CreateMap<DataBase.User, Models.Api.User.UserViewModel>();

        }
 
        protected void TrainingMap()
        {
            CreateMap<Training.TrainingViewModel, DataBase.Training>()
                .ForMember(p => p.TrainingPlan, o => o.Ignore())
                .ForMember(p => p.ExercisesDone, o => o.Ignore());

            CreateMap<DataBase.Training, Training.TrainingFormModel>()
                .ForMember(p => p.ExercisesDone, o => o.Ignore());
                

            CreateMap<Training.TrainingFormModel, DataBase.Training>()
                .ForMember(p => p.UserId, o => o.Ignore())
                .ForMember(p => p.ExecutionTime, o => o.Ignore())
                .ForMember(p => p.Id, o => o.Ignore())
                .ForMember(p => p.ExercisesDone, o => o.Ignore())
                .ForMember(p => p.TrainingPlan, o => o.Ignore());


            CreateMap<DataBase.Training, Training.TrainingViewModel>()
                .ForMember(p => p.ExercisesDone, o => o.MapFrom(x => x.ExercisesDone))
                .ForMember(p => p.AvgPulse, o =>
                {
                    o.MapFrom(x => x.ExercisesDone.Average(z => z.Pulse));
                });
                


        }

        protected void ExerciseDoneMap()
        {
            CreateMap<ExercisesDone.ExerciseDoneFormModel, DataBase.ExerciseDone>()
                .ForMember(p => p.Training, o => o.Ignore())
                .ForMember(p => p.TrainingId, o => o.Ignore());

            CreateMap<DataBase.ExerciseDone, ExerciseDone.ExerciseDoneViewModel>();
  
        }

        protected void UserMeasurementsMap()
        {
            CreateMap<UserMeasurements.UserMeasurementsFormModel, DataBase.UserMeasurement>()
                .ForMember(p => p.User, o => o.Ignore());
            CreateMap<DataBase.UserMeasurement, UserMeasurements.UserMeasurementsViewModel>();
                
        }





        protected void TrainingPlanMap()
        {
            CreateMap<DataBase.TrainingPlan, TrainingPlan.TrainingPlanFormModel>()
                .ForMember(p => p.ExerciseId, o => o.Ignore());

            CreateMap<TrainingPlan.TrainingPlanFormModel, DataBase.TrainingPlan>()
                .ForMember(p => p.Trainings, o => o.Ignore())
                .ForMember(p => p.TrainingPlanExercises, o => o.Ignore())
                .ForMember(p => p.User, o => o.Ignore());
        }
        
        protected void ExerciseMap()
        {
            CreateMap<Exercise.ExerciseFormModel, DataBase.Exercise>()
                .ForMember(p => p.Id, o => o.Ignore())
                .ForMember(p => p.TrainingPlanExercises, o => o.Ignore());


            CreateMap<DataBase.Exercise, Exercise.ExerciseFormModel>();
        }
        
    }
}

using AutoMapper;
using GymApp.Data;
using GymApp.Models.Api.UserMeasurements;
using GymApp.Models.DataBase;
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


namespace GymApp.Services.UserMeasurementsService
{
    public class UserMeasurementsService : IUserMeasurementsService
    {
        private readonly DataContext context;
        private IMapper mapper { get; }
        public UserMeasurementsService(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public UserMeasurement Create(UserMeasurementsFormModel model)
        {
            var measurement = mapper.Map<UserMeasurement>(model);


            context.Add<UserMeasurement>(measurement);
            context.SaveChanges();

            return measurement;
        }
        public List<UserMeasurementsViewModel> Fetch(long uid)
        {
            var result = context.UserMeasurements
                                .Where(p => p.Id == uid)
                                .ToList();

            return mapper.Map<List<UserMeasurementsViewModel>>(result);
        }
        public UserMeasurement Update(UserMeasurementsFormModel model, long measurementId)
        {
            var entity = context.UserMeasurements
                                .Where(p => p.Id == measurementId)
                                .FirstOrDefault();

            var result = mapper.Map<UserMeasurementsFormModel, UserMeasurement>(model, entity);

            context.Update<UserMeasurement>(result);
            context.SaveChanges();

            return result;
        }
        

    }
}

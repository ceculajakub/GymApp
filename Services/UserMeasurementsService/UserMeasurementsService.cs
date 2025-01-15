using System.Collections.Generic;
using AutoMapper;
using GymApp.Models.Api.UserMeasurements;
using GymApp.Models.DataBase;
using GymApp.Repositories;

namespace GymApp.Services.UserMeasurementsService
{
    public class UserMeasurementsService : IUserMeasurementsService
    {
        private readonly IUserMeasurementsRepository _userMeasurementsRepository;
        private IMapper _mapper { get; }

        public UserMeasurementsService(IUserMeasurementsRepository userMeasurementsRepository, IMapper mapper)
        {
            _userMeasurementsRepository = userMeasurementsRepository;
            _mapper = mapper;
        }

        public UserMeasurement Create(UserMeasurementsFormModel model)
        {
            var measurement = _mapper.Map<UserMeasurement>(model);
            return _userMeasurementsRepository.Add(measurement);
        }

        public List<UserMeasurementsViewModel> Fetch(int uid)
        {
            var measurements = _userMeasurementsRepository.GetByUserId(uid);
            return _mapper.Map<List<UserMeasurementsViewModel>>(measurements);
        }

        public UserMeasurement Update(UserMeasurementsFormModel model, int measurementId)
        {
            var existingMeasurement = _userMeasurementsRepository.GetById(measurementId);

            if (existingMeasurement == null)
                return null;

            var updatedMeasurement = _mapper.Map(model, existingMeasurement);
            return _userMeasurementsRepository.Update(updatedMeasurement);
        }
    }
}
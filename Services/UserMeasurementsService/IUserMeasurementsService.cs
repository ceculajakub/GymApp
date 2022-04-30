using GymApp.Models.Api.UserMeasurements;
using GymApp.Models.DataBase;
using System.Collections.Generic;

namespace GymApp.Services.UserMeasurementsService
{
    public interface IUserMeasurementsService
    {
        UserMeasurement Create(UserMeasurementsFormModel measurement);
        List<UserMeasurementsViewModel>Fetch(int UserId);
        UserMeasurement Update(UserMeasurementsFormModel measurement, int UserMeasurementId);
        
    }
}

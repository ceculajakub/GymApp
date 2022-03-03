using GymApp.Models.Api.User;
using GymApp.Models.DataBase;

namespace GymApp.Services.UserService
{
    public interface IUserService
    {
        User Login(string userName, string password);
        User Create(UserFormModel user, string password);
        bool UserExists(string userName);
        User Fetch(long id);
        User Update(UserFormModel model, User user);
    }
}

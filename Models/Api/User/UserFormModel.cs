using System;
namespace GymApp.Models.Api.User
{
    public class UserFormModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Weight { get; set; }
        public float Height { get; set; }
        public string Gender { get; set; }
        public float Bmi { get; set; }
    }
}

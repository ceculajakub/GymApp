using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymApp.Models.Api.User
{
    public class UserViewModel
    {
        public string Username { get; set; }
        public int Weight { get; set; }
        public float Height { get; set; }
        public string Gender { get; set; }
        public float Bmi { get; set; }
    }
}

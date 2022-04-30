using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GymApp.Models.DataBase
{
    public class User
    {
        public User()
        {
            UserGoals = new HashSet<UserGoal>();
            TrainingPlans = new HashSet<TrainingPlan>();
            UserMeasurements = new HashSet<UserMeasurement>();
        }

        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public string Gender { get; set; }

        
        public float Bmi { get; private set; }

        public ICollection<UserGoal> UserGoals { get; set; }
        public ICollection<TrainingPlan> TrainingPlans { get; set; }
        public ICollection<UserMeasurement> UserMeasurements { get; set; }
    }
}

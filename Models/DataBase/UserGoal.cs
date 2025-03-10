﻿using System.ComponentModel.DataAnnotations;

namespace GymApp.Models.DataBase
{
    public class UserGoal
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }

        public User User { get; set; }
    }
}

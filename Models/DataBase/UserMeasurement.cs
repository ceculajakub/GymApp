﻿using System.ComponentModel.DataAnnotations;

namespace GymApp.Models.DataBase
{
    public class UserMeasurement
    {
        [Key]
        public int Id { get; set; }
        public int Type { get; set; }
        public double Value { get; set; }
        

        public User User { get; set; }
    }
}

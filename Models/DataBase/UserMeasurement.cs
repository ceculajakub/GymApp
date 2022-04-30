using System.ComponentModel.DataAnnotations;

namespace GymApp.Models.DataBase
{
    public class UserMeasurement
    {
        [Key]
        public long Id { get; set; }
        public int Type { get; set; }
        public long Value { get; set; }
        

        public User User { get; set; }
    }
}

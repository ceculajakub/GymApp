using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymApp.Models.DataBase
{
    public class ExerciseDone
    {
        [Key]
        public long Id { get; set; }
        public long TrainingId { get; set; }
        public long ExerciseId { get; set; }
        public long Reps { get; set; }
        public long Weight { get; set; }
        public string Equipment { get; set; }
        public int Pulse { get; set; }

        public Training Training { get; set; }
    }
}

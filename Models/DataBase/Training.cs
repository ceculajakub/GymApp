using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymApp.Models.DataBase
{
    public class Training
    {
        public Training()
        {
            ExercisesDone = new HashSet<ExerciseDone>();
        }

        [Key]
        public long Id { get; set; }
        public long TrainingPlanId { get; set; }
        public long UserId { get; set; }
        public DateTime ExecutionTime { get; set; }
        public string Attention { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int? AvgPulse { get; set; }

        public TrainingPlan TrainingPlan { get; set; }
        public ICollection<ExerciseDone> ExercisesDone { get; set; }
    }
}

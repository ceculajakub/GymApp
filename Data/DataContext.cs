using GymApp.Models.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;

namespace GymApp.Data
{
    public class DataContext : DbContext
    {

        public readonly string _connectionString;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            _connectionString = ((SqlServerOptionsExtension)options.Extensions.First()).ConnectionString;
       
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .Property(p => p.Bmi)
                .HasComputedColumnSql($"[Weight] / ([Height] * [Height]");

            builder.Entity<Training>()
                .Property(x => x.AvgPulse)
                .HasComputedColumnSql($"AVG([ExerciseDone.Pulse])");
                
            
                
                
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<UserGoal> UserGoals { get; set; }
        public DbSet<TrainingPlan> TrainingPlans { get; set; }
        public DbSet<TrainingPlanExercise> TrainingPlanExercises { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<ExerciseDone> ExercisesDone { get; set; }
        public DbSet<UserMeasurement> UserMeasurements { get; set; }
    }
}

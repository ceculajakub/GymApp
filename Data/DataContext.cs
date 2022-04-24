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

        

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
       
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
          .AddJsonFile("appsettings.json")
          .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .Property(p => p.Bmi)
                .HasComputedColumnSql($"[Weight] / ([Height] * [Height]");

            
                
            
                
                
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

using ggsport.Authentication.Model.Entity;
using ggsport.Domain.Client;
using ggsport.Domain.Course;
using ggsport.Domain.Manager;
using ggsport.Domain.Room;
using ggsport.Domain.Schedule.Model.Entity;
using ggsport.Domain.Trainer.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks.Dataflow;

namespace ggsport.Infrastructure;

public class GGSportContext(DbContextOptions<GGSportContext> context) : DbContext(context)
{
    public DbSet<UserModel> Users { get; set; }
    public DbSet<RoleModel> Roles { get; set; }
    public DbSet<ClientModel> Clients { get; set; }
    public DbSet<ClubCardModel> ClubCards { get; set; }
    public DbSet<CourseModel> Courses { get; set; }
    public DbSet<ExerciseModel> Exercises { get; set; }
    public DbSet<ManagerModel> Managers { get; set; }
    public DbSet<RoomModel> Room { get; set; }
    public DbSet<ScheduleModel> Schedules { get; set; }
    public DbSet<TrainerModel> Trainers { get; set; }
    public DbSet<ScheduleTrainer> ScheduleTrainers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();

        modelBuilder.Entity<RoleModel>().HasData(new RoleModel { Id = 1, Name = "user" }, new RoleModel { Id = 2, Name = "admin" });
        modelBuilder.Entity<UserModel>().HasData(
            new UserModel
            {
                Id = 10,
                Email = "jounknown25@gmail.com",
                Password = "AQAAAAIAAYagAAAAEIW4K7vlpfFbsxyP16AoSghbhHLy+NqYBhE/Hj7PxRlkIaTApku4+D9rVKGrLQlxcA==",
                IsEmailConfirmed = true,
                RoleId = 1
            });

        modelBuilder.Entity<ScheduleModel>()
        .HasMany(e => e.Trainers)
        .WithMany(e => e.Schedules)
        .UsingEntity<ScheduleTrainer>();

        modelBuilder.Entity<ScheduleModel>()
        .HasMany(e => e.Clients)
        .WithMany(e => e.Schedules)
        .UsingEntity<ScheduleClient>();

        base.OnModelCreating(modelBuilder);
    }
}

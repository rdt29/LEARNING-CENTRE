using LearningCentre.Infra.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Infra.Domain
{
    public class LearningCentreContext : DbContext
    {
        public LearningCentreContext(DbContextOptions<LearningCentreContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<AssignTask> AssignTasks { get; set; }

        public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<TaskEvaluation> TaskEvaluations { get; set; }
        public DbSet<UserRoleMapping> UserRoleMappings { get; set; }
        public DbSet<SubmittedTasks> SubmittedTasks { get; set; }
    }
}
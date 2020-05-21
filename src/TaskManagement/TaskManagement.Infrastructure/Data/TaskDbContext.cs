using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Core.Model.BoardAggregate;
using TaskManagement.Infrastructure.EntityConfigurations;

namespace TaskManagement.Infrastructure.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {

        }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Board> Boards { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.ApplyConfiguration(new TaskEntityTypeConfiguration());
        }


    }
}

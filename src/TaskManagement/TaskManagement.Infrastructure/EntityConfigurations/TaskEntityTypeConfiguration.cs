using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Core.Model.BoardAggregate;
using Task = TaskManagement.Core.Model.BoardAggregate.Task;

namespace TaskManagement.Infrastructure.EntityConfigurations
{
    class TaskEntityTypeConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasOne<Board>()
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.BoardId);
        }
    }
}

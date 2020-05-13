using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Core.SeedWork;

namespace TaskManagement.Core.Model.TaskAggregate
{
    public class Task : Entity<int>
    {
        public string Name { get; set; }
    }
}

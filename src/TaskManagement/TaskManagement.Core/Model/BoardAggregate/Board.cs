using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Core.SeedWork;

namespace TaskManagement.Core.Model.BoardAggregate
{
    public class Board : Entity<Guid>
    {
        public string Name { get; set; }
       
        private List<Task> _tasks;

        public IEnumerable<Task> Tasks
        {
            get { return _tasks.AsEnumerable(); }
            private set { _tasks = (List<Task>) value; }
        }
        
    }
}

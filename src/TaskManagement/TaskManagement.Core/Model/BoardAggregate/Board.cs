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
            private set { _tasks = (List<Task>)value; }
        }
        private Board()
        {
            Id = Guid.NewGuid();
            _tasks = new List<Task>();
        }

        public Board(string boardName):this()
        {
            
            Name = boardName;
            
        }

        public Task AddTask(Task addTask)
        {
            if (_tasks.Any(t => t.Id == addTask.Id))
            {
                throw new ArgumentException("Can't add duplicate Task to Board.", "task");
            }
            _tasks.Add(addTask);
            return addTask;
        }

        public void DeleteTask(Task deleteTask)
        {
            _tasks.Remove(deleteTask);
        }
       
        
    }
}

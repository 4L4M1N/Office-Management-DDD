using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Core.SeedWork;

namespace TaskManagement.Core.Model.TaskAggregate
{
    public class Task : Entity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime AssignDate { get; set; }
        public DateTime CompleteDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public Guid SupervisorId { get; set; }
        public Guid TeamMemberId { get; set; }
        private Task()
        {
            
        }
        public void UpdateAssignDate(DateTime newAssignDate)
        {
            if (newAssignDate == AssignDate) return;
            AssignDate = newAssignDate;
        }

        public void UpdateDeadline(DateTime newDueDate)
        {
            if (newDueDate == DueDate) return;
            DueDate = DueDate;
        }

        public static Task Create(string name, string description, DateTime assignDate, DateTime dueDate, Guid supervisorId)
        {
            var task = new Task();
            task.Name = name;
            task.Description = description;
            task.AssignDate = assignDate;
            task.DueDate = dueDate;
            task.IsCompleted = false;
            task.SupervisorId = supervisorId;
            return task;
        }

        public void Complete(bool isComplete)
        {
            IsCompleted = true;
            CompleteDate = DateTime.Now;
        }

        public void AssignTo(Guid teamMemberId)
        {
            TeamMemberId = teamMemberId;
        }

    }
}

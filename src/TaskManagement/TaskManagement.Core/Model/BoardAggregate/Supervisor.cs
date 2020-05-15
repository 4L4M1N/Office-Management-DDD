using System;
using TaskManagement.Core.SeedWork;

namespace TaskManagement.Core.Model.BoardAggregate
{
    public class Supervisor : Entity<Guid>
    {
        public string Name { get; set; }

        private Supervisor()
        {
            
        }

        private Supervisor(Guid id)
        {
            Id = id;
        }

        public static Supervisor Create(Guid id, string name)
        {
             var supervisor = new Supervisor(id);
             supervisor.Name = name;
             return supervisor;
        }
    }
}

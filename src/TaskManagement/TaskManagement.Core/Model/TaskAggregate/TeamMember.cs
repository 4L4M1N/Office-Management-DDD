using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Core.SeedWork;

namespace TaskManagement.Core.Model.TaskAggregate
{
    public class TeamMember : Entity<Guid>
    {
        public string Name { get; set; }

        private TeamMember()
        {
            
        }

        private TeamMember(Guid id)
        {
            Id = id;
        }

        public static TeamMember Create(Guid id, string name)
        {
            var teamMember = new TeamMember(id);
            teamMember.Name = name;
            return teamMember;
        }
    }
}

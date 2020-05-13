using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagement.Core.SeedWork
{
    public abstract class Entity<TId>
    {
        public TId Id { get; protected set; }
    }

}

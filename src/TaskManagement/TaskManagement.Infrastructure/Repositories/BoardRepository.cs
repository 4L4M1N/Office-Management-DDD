using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Core.Interfaces;
using TaskManagement.Core.Model.BoardAggregate;
using TaskManagement.Infrastructure.Data;
using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Infrastructure.Repositories
{
    public class BoardRepository : IBoardRepository, IDisposable
    {
        private readonly TaskDbContext _context;

        public BoardRepository(TaskDbContext context)
        {
            _context = context;
        }
        public Board Add(Board addBoard)
        {
            //TODO: May have Bug
            var result =  _context.Boards.Add(addBoard).Entity;
            _context.SaveChanges();
            return result;
        }

        public void Update(Board updatedBoard)
        {
            _context.Entry(updatedBoard).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void GetAllBoard()
        {
            //var result = _context.Boards
        }

        //TODO: Learn about IDisposable
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}

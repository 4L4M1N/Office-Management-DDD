using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Core.Model.BoardAggregate;
using TaskManagement.Infrastructure.Data;
using Task = TaskManagement.Core.Model.BoardAggregate.Task;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly TaskDbContext _context;
        public TestController(TaskDbContext context)
        {
            _context = context;
        }
        [HttpGet("allboard")]
        public async Task<IActionResult>AllBoard()
        {
            //var board = new Board("first board");
            //var task = Task.Create("first", "test", DateTime.Today, DateTime.Today, Guid.NewGuid(), Guid.NewGuid());
            //board.AddTask(task);
            //_context.Boards.Add(board);
            //_context.SaveChanges();
           string a = "Success";
           
            // var first = _context.Boards.FirstOrDefault();
            // _context.Boards.Remove(first);
            // var i = _context.SaveChanges();
            return Ok(a);
        }
    }
}
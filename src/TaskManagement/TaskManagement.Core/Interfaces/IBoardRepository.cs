using TaskManagement.Core.Model.BoardAggregate;
using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Core.Interfaces
{
    public interface IBoardRepository
    {
        Board Add(Board addBoard);
        void Update(Board updatedBoard);
    }
}
using System.Threading.Tasks;

namespace Identity.Interfaces
{
    public interface IAccountService
    {
         Task<bool> SaveRoles();
    }
}
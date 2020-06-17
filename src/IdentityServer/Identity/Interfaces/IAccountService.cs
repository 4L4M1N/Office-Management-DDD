using System.Threading.Tasks;
using Identity.Models;

namespace Identity.Interfaces
{
    public interface IAccountService
    {
         Task<bool> SaveRoles();
         Task<bool> SaveRoleToAUser(string role, ApplicationUser user);
    }
}
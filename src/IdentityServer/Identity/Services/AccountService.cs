using System.Linq;
using System.Threading.Tasks;
using Identity.Data;
using Identity.Interfaces;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Identity.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly TaskIdentityDbContext _context;
        public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
                                RoleManager<IdentityRole> roleManager, TaskIdentityDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }
        public  async Task<bool> SaveRoles()
        {
            //SuperAdmin
            if (!await _roleManager.RoleExistsAsync(Roles.SuperAdmin))
            {
                await _roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin));
            }
            //CourierOwner
            if (!await _roleManager.RoleExistsAsync(Roles.Admin))
            {
                await _roleManager.CreateAsync(new IdentityRole(Roles.Admin));
            }
            //BookingOfficer
            if (!await _roleManager.RoleExistsAsync(Roles.Manager))
            {
                await _roleManager.CreateAsync(new IdentityRole(Roles.Manager));
            }
             if (!await _roleManager.RoleExistsAsync(Roles.Employee))
            {
                await _roleManager.CreateAsync(new IdentityRole(Roles.Employee));
            }
            var result = await _context.SaveChangesAsync();
            if(result > 0)
            {
                return true;
            }
            return false;

        }

        public async Task<bool> SaveRoleToAUser(string saveRole, ApplicationUser userCreated)
        {
            var result = await _context.Roles.FirstOrDefaultAsync(x=>x.Name == saveRole);
            if(result != null)
            {
                await _userManager.AddToRoleAsync(userCreated, result.Name);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
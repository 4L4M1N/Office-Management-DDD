using System.Threading.Tasks;
using Identity.Data;
using Identity.Interfaces;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
            var result = await _context.SaveChangesAsync();
            if(result > 0)
            {
                return true;
            }
            return false;

        }
}
}
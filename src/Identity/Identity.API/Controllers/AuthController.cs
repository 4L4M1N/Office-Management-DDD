using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Identity.API.DTOs;
using Identity.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AuthController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Registration(UserForRegistrationDTO userForRegistrationDTO)
        {
            //SuperAdmin
            if (!await _roleManager.RoleExistsAsync(Role.SuperAdmin))
            {
                await _roleManager.CreateAsync(new IdentityRole(Role.SuperAdmin));
            }
            //CourierOwner
            if (!await _roleManager.RoleExistsAsync(Role.Employee))
            {
                await _roleManager.CreateAsync(new IdentityRole(Role.Employee));
            }
            //Create User Object
            var userToCreate = new AppUser
            {
                UserName = userForRegistrationDTO.UserName,
                Email = userForRegistrationDTO.UserName

            };
            if (await _userManager.FindByNameAsync(userForRegistrationDTO.UserName) != null)
                return BadRequest("User name already exists!");

            var createdUser = await _userManager.CreateAsync(userToCreate, userForRegistrationDTO.Password);
            if (createdUser.Succeeded)
            {
                if (userForRegistrationDTO.Role == "SuperAdmin")
                {
                    await _userManager.AddToRoleAsync(userToCreate, Role.SuperAdmin);
                }
                else if (userForRegistrationDTO.Role == "Employee")
                {
                    await _userManager.AddToRoleAsync(userToCreate, Role.Employee);
                }
                else { return BadRequest(); }

                return Ok(createdUser);
            }
            //Create User
            return BadRequest(ModelState);
        }
    }
}
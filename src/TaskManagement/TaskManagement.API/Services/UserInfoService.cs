using System;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace TaskManagement.API.Services
{
    public class UserInfoService : IUserInfoService
    {
         private readonly IHttpContextAccessor _httpContextAccessor;
         public string UserId { get; set; }
         public string Name { get; set; }
         public string Email { get; set; }
         public string Role { get; set; }
         public UserInfoService(IHttpContextAccessor httpContextAccessor)
         {
             _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
             var currentContext = _httpContextAccessor.HttpContext;
             if(currentContext == null || !currentContext.User.Identity.IsAuthenticated)
             {
                 return;
             }
            UserId = currentContext
                .User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

            Name = currentContext.User
                .Claims.FirstOrDefault(c => c.Type == "name")?.Value;

            Email = currentContext
                .User.Claims.FirstOrDefault(c => c.Type == "email")?.Value;

            Role = currentContext
                .User.Claims.FirstOrDefault(c => c.Type == "role")?.Value;
         }
    }
}
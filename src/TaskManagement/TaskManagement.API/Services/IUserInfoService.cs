namespace TaskManagement.API.Services
{
    public interface IUserInfoService
    {
         public string UserId { get; set; }
         public string Name { get; set; }
         public string Email { get; set; }
         public string Role { get; set; }
    }
}
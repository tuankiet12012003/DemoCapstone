using UserService.Models;

namespace UserService.Services.Interface
{
    public interface IUserService
    {
        Task<List<Users>> GetAllUsers();
        Task<Users> GetUserById(int id);
        Task AddUser(Users user);
        Task UpdateUser(Users user);
        Task DeleteUser(int id);
    }
}

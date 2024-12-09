using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Models;
using UserService.Services.Interface;

namespace UserService.Services
{
    public class UserServiceHandler : IUserService
    {
        private readonly UserDbContext _context;

        public UserServiceHandler(UserDbContext context)
        {
            _context = context;
        }
        public async Task AddUser(Users user)
        {
            try
            {
                var existingUser = await GetUserById(user.Id);
                if (existingUser != null)
                {
                    throw new Exception("User already exists");
                }
                else
                {
                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteUser(int id)
        {
            try
            {
                var existingUser = await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (existingUser == null)
                {
                    throw new Exception("User not found");
                }
                _context.Users.Remove(existingUser);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Users>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Users> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateUser(Users user)
        {
            try
            {
                var existingUser = await GetUserById(user.Id);
                if (existingUser == null)
                {
                    throw new Exception("User does not exist");
                }

                existingUser.Username = user.Username;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;

                _context.Users.Update(existingUser);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
        Task UpdateResetTokenAsync(int userId, string token, DateTime expiry);
        Task<User?> GetUserByResetTokenAsync(string token);
    }
}
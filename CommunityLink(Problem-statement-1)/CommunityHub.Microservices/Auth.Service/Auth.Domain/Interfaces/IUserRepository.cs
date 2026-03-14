using Auth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<UserAccount?> GetByIdAsync(Guid id);
        Task<UserAccount?> GetByEmailAsync(string email);
        Task AddAsync(UserAccount user);
        Task<IEnumerable<UserAccount>> GetAllAsync();
    }
}

using Auth.Domain.Entities;
using Auth.Domain.Interfaces;
using Auth.Infrastructure.Persistence;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Repositories
{
    public class UserRepository : Auth.Domain.Interfaces.IUserRepository
    {
        private readonly Auth.Infrastructure.Persistence.MongoDbContext _context;

        public UserRepository(Auth.Infrastructure.Persistence.MongoDbContext context)
        {
            _context = context;
        }

        public async Task<UserAccount?> GetByIdAsync(Guid id)
        {
            return await _context.Users.Find(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<UserAccount?> GetByEmailAsync(string email)
        {
            return await _context.Users.Find(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task AddAsync(UserAccount user)
        {
            await _context.Users.InsertOneAsync(user);
        }

        public async Task<IEnumerable<UserAccount>> GetAllAsync()
        {
            return await _context.Users.Find(_ => true).ToListAsync();
        }
    }
}

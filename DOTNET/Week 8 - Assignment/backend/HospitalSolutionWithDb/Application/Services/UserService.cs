using Application.DTOs;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<UserResponseDto>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();

            return users.Select(u => new UserResponseDto
            {
                Id = u.Id,
                Email = u.Email,
                Role = u.Role
            });
        }

        public async Task<UserResponseDto?> GetByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return null;

            return new UserResponseDto
            {
                Id = user.Id,
                Email = user.Email,
                Role = user.Role
            };
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
using Event.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Event.Domain.Interfaces
{
    public interface IEventRepository
    {
        Task<EventEntry?> GetByIdAsync(Guid id);
        Task<IEnumerable<EventEntry>> GetAllAsync();
        Task AddAsync(EventEntry @event);
        Task UpdateAsync(EventEntry @event);
        Task DeleteAsync(Guid id);
    }
}

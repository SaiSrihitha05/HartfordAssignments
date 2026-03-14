using Event.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Event.Application.Interfaces
{
    public interface IEventService
    {
        Task<EventDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<EventDto>> GetAllAsync();
        Task<EventDto> CreateAsync(CreateEventRequest request);
        Task<bool> UpdateAsync(Guid id, UpdateEventRequest request);
        Task<bool> DeleteAsync(Guid id);
    }
}

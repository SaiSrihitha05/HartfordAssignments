using Event.Application.DTOs;
using Event.Application.Interfaces;
using Event.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _repository;

        public EventService(IEventRepository repository)
        {
            _repository = repository;
        }

        public async Task<EventDto?> GetByIdAsync(Guid id)
        {
            var @event = await _repository.GetByIdAsync(id);
            if (@event == null) return null;
            return new EventDto(@event.Id, @event.Title, @event.Description, @event.Location, @event.EventDate, @event.CreatedBy);
        }

        public async Task<IEnumerable<EventDto>> GetAllAsync()
        {
            var events = await _repository.GetAllAsync();
            return events.Select(e => new EventDto(e.Id, e.Title, e.Description, e.Location, e.EventDate, e.CreatedBy));
        }

        public async Task<EventDto> CreateAsync(CreateEventRequest request)
        {
            var @event = new Event.Domain.Entities.EventEntry
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Location = request.Location,
                EventDate = request.EventDate,
                CreatedBy = request.CreatedBy
            };

            await _repository.AddAsync(@event);
            return new EventDto(@event.Id, @event.Title, @event.Description, @event.Location, @event.EventDate, @event.CreatedBy);
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateEventRequest request)
        {
            var @event = await _repository.GetByIdAsync(id);
            if (@event == null) return false;

            @event.Title = request.Title;
            @event.Description = request.Description;
            @event.Location = request.Location;
            @event.EventDate = request.EventDate;

            await _repository.UpdateAsync(@event);
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var @event = await _repository.GetByIdAsync(id);
            if (@event == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}

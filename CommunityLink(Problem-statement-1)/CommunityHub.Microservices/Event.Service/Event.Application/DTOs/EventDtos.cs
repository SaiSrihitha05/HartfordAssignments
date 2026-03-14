using System;

namespace Event.Application.DTOs
{
    public record EventDto(Guid Id, string Title, string Description, string Location, DateTime EventDate, string CreatedBy);
    public record CreateEventRequest(string Title, string Description, string Location, DateTime EventDate, string CreatedBy);
    public record UpdateEventRequest(string Title, string Description, string Location, DateTime EventDate);
}

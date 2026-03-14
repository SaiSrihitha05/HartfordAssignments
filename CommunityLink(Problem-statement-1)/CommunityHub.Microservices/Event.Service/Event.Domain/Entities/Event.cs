using System;

namespace Event.Domain.Entities
{
    public class EventEntry
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime EventDate { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
    }
}

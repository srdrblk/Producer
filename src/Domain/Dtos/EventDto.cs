
using System;


namespace Domain
{
    public class EventDto 
    {
        public string Id { get; private set; }
        public string LocationId { get; private set; }
        public string Title { get; private set; }
        public bool Complated { get; private set; }

        public EventDto()
        {
            Id = Guid.NewGuid().ToString(); 
        }
        public EventDto(string locationId, string title, bool complated) : this()
        {
            LocationId = locationId;
            Title = title;
            Complated = complated;
        }
        public EventDto(string id,string locationId, string title, bool complated) : this(locationId,title,complated)
        {
            Id = id;
        }
    }
}

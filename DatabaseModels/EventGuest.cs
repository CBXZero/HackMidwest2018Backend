using System;
using System.Collections.Generic;

namespace HackMidwest2018Backend.DatabaseModels
{
    public class EventGuest
    {
        public int EventGuestId {get; set;}
        public int EventId {get; set;}
        public Event Event {get; set;}
        public int contactGuestId {get; set;}
        public Contact Guest {get; set;}
        public bool Attending {get; set;}
    }
}
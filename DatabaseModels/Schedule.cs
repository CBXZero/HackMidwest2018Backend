using System;
using System.Collections.Generic;

namespace HackMidwest2018Backend.DatabaseModels
{
    public class Schedule
    {
        public int ScheduleId {get; set;}
        public DateTime EventDate {get; set;}
        public int EventId {get; set;}
        public Event Event {get; set;}

    }
}
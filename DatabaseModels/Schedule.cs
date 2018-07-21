using System.Collections.Generic;

namespace HackMidwest2018Backend.DatabaseModels
{
    public class Schedule
    {
        public int ScheduleId {get; set;}
        public Event Event {get; set;}
        public ICollection<Schedule> Schedules {get; set;}  
    }
}
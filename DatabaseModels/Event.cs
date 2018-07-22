using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackMidwest2018Backend.DatabaseModels
{
    public class Event
    {
        public int EventId {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public int OwnerContactId {get; set;}

        public Contact Owner {get; set;}
        
        public List<Schedule> Schedules {get; set;}
        public List<Contribution> Contributions {get; set;}
    }
}
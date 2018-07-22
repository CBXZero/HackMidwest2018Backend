using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackMidwest2018Backend.DatabaseModels
{
    public class Contribution
    {
        public int ContributionId {get; set;}
        public string Description {get; set;}

        public int ContributerContactId {get; set;}
        public Contact Contributer {get; set;}

        public int EventId {get; set;}
        public Event Event {get; set;}
    }
}
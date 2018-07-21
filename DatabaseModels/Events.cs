using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HackMidwest2018Backend.DatabaseModels
{
    public class Event
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public Contact Owner {get; set;}
    }
}
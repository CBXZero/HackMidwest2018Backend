using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackMidwest2018Backend.DatabaseModels
{
    public class Contact
    {
        public int ContactId {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string PhoneNumber {get; set;}
        public string Email {get; set;}
        public List<Event> OwnedEvents {get; set;}
        public List<EventGuest> GuestEvents {get; set;}
        public List<Contribution> Contributions {get; set;}
    }
}
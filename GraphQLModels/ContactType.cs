using GraphQL.Types;
using HackMidwest2018Backend.DatabaseModels;
using HackMidwest2018Backend.DatabaseContext;

namespace GraphQLModels {
    public class ContactType : ObjectGraphType<Contact>
    {
        public ContactType()
        {
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field(x => x.PhoneNumber);
            Field(x => x.ContactId);
            Field(x => x.Email);
            Field(x => x.OwnedEvents, type: typeof(ListGraphType<EventType>));
            Field(x => x.GuestEvents, type: typeof(ListGraphType<EventGuestType>));
            Field(x => x.Contributions, type: typeof(ListGraphType<ContrubutionType>));
        }
    }
}
using GraphQL.Types;
using HackMidwest2018Backend.DatabaseModels;

namespace GraphQLModels {
    public class EventGuestType : ObjectGraphType<EventGuest>
    {
        public EventGuestType()
        {
            Field(x => x.EventGuestId);
            Field(x => x.EventId);
            Field(x => x.Event, type: typeof(EventType));
            Field(x => x.contactGuestId);
            Field(x => x.Guest, type: typeof(ContactType));
            Field(x => x.Attending);
        }
    }
}
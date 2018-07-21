using GraphQL.Types;
using HackMidwest2018Backend.DatabaseModels;
using HackMidwest2018Backend.DatabaseContext;

namespace GraphQLModels {
    public class EventType : ObjectGraphType<Event>
    {
        public EventType(PartyContext context)
        {
            Field(x => x.EventId);
            Field(x => x.Name);
            Field(x => x.Description);
            Field(x => x.Owner);
        }
    }
}
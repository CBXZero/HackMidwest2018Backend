using GraphQL.Types;
using System.Linq;
using System.Collections.Generic;
using GraphQLModels;
using HackMidwest2018Backend.DatabaseModels;
using HackMidwest2018Backend.DatabaseContext;

namespace HackMidwest2018Backend.GraphQLModels
{
    public class EventMutation : ObjectGraphType<object>
    {
        public EventMutation()
        {
            var db = new PartyContext();

            Field<EventType>(
                "createEvent",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<EventInputType>> {Name = "event"}
                ),
                resolve: context =>
                {
                    var ev = context.GetArgument<Event>("event");
                    db.Events.Add(ev);
                    db.SaveChanges();
                    return ev;
                });
        }
    }
}
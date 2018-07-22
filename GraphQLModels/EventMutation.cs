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
            Field<EventType>(
                "createEvent",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<EventInputType>> {Name = "human"}
                ),
                resolve: context =>
                {
                    var ev = context.GetArgument<Event>("event");
                    return ev;
                });
        }
}
    public class EventInputType : InputObjectGraphType
    {
        public EventInputType()
        {
            Name = "EventInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<StringGraphType>("homePlanet");
        }
    }
}
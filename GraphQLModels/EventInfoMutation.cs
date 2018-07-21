using GraphQL.Types;
using GraphQLModels;
using HackMidwest2018Backend.DatabaseContext;

public class EventInfoMutation : ObjectGraphType
    {
        public EventInfoMutation(PartyContext context)
        {
            //  Field<EventType>(
            //     "createEvent",
            //     arguments: new QueryArguments(
            //         new QueryArgument<NonNullGraphType<EventInputType>> { Name = "event" }
            //     ),
            //     resolve: fieldContext =>
            //     {
            //         var player = context.GetArgument<Player>("player");
            //         return playerRepository.Add(player);
            //     });
        }
    }
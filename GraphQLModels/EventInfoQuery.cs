using GraphQL.Types;
using GraphQLModels;
using HackMidwest2018Backend.DatabaseContext;
public class EventInfoQuery : ObjectGraphType
    {
        public EventInfoQuery(PartyContext context)
        {
            Field<EventType>(
                "player",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>  playerRepository.Get(context.GetArgument<int>("id")));
        }
    }
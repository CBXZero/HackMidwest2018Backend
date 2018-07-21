using GraphQL.Types;
using GraphQLModels;

public class EventInfoMutation : ObjectGraphType
    {
        public EventInfoMutation(IPlayerRepository playerRepository)
        {
            Field<EventType>(
                "player",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>  playerRepository.Get(context.GetArgument<int>("id")));

            Field<EventType>(
                "randomPlayer",
                resolve: context => playerRepository.GetRandom());

            Field<ListGraphType<EventType>>(
                "players",
                resolve: context => playerRepository.All());
        }
    }
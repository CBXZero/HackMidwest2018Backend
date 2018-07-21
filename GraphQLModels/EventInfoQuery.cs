using GraphQL.Types;
using System.Linq;
using System.Collections.Generic;
using GraphQLModels;
using HackMidwest2018Backend.DatabaseContext;
public class EventInfoQuery : ObjectGraphType
    {
        public EventInfoQuery(PartyContext db)
        {
            
            Field<EventType>(
                "event",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "EventId" }),
                resolve: context =>  db.Events.FirstOrDefault(x => x.EventId == 1));//playerRepository.Get(context.GetArgument<int>("id")))

            // Field<EventType>(
            //     "randomPlayer",
            //     resolve: context => playerRepository.GetRandom());

            // Field<ListGraphType<EventType>>(
            //     "players",
            //     resolve: context => playerRepository.All());
        }
    }
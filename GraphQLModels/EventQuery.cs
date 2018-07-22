using GraphQL.Types;
using System.Linq;
using System.Collections.Generic;
using GraphQLModels;
using HackMidwest2018Backend.DatabaseContext;

namespace HackMidwest2018Backend.GraphQLModels
{
    public class EventQuery : ObjectGraphType
    {
        public EventQuery()
        {
            var db = new PartyContext();

            Field<EventType>(
                "event",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "eventId" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("eventId");
                    var objectId = (int)context.Arguments["eventId"];
                    return db.Events.FirstOrDefault(e => e.EventId == objectId);
                }
            );

            // Field<EventType>(
            //     "eventOwner",
            //     arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "email" }),
            //     resolve: context =>
            //     {
            //         var id = context.GetArgument<string>("email");
            //         var objectId = (string)context.Arguments["email"];
            //         return db.Events.FirstOrDefault(e => e.Owner.Email == objectId);
            //     } 
            // );

            Field<ListGraphType<EventType>>(
              "events",
              resolve: context => db.Events.ToList());
        }
    }
}
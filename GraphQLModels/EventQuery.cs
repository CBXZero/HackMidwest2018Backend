using GraphQL.Types;
using System.Linq;
using System.Collections.Generic;
using GraphQLModels;
using HackMidwest2018Backend.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HackMidwest2018Backend.GraphQLModels
{
    public class EventQuery : ObjectGraphType
    {
        public EventQuery()
        {
            var db = new PartyContext();

            Field<ListGraphType<EventType>>(
                "event",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "email" },
                new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    if (context.Arguments.ContainsKey("id"))
                    {
                        var id = (int)context.Arguments["id"];

                        return db.Events
                            .Include(e => e.Contributions).Where(e => e.EventId == id)
                            .Include(e => e.Owner)
                            .Include(e => e.Schedules)
                            .Include(p => p.EventGuests)
                            .ThenInclude(p => p.Guest);
                    }

                    var email = (string)context.Arguments["email"];
                    return db.Events
                    .Include(e => e.Owner)
                    .Include(e => e.Schedules)
                    .Include(e => e.Contributions).Where(e => e.Owner.Email == email)
                    .Include(p => p.EventGuests)
                    .ThenInclude(p => p.Guest);
                }
            );

            Field<ListGraphType<EventType>>(
              "events",
              resolve: context => db.Events
                .Include(e => e.Owner)
                .Include(e => e.Schedules)
                .Include(e => e.Contributions)
                .Include(p => p.EventGuests)
                .ThenInclude(p => p.Guest)
                .ToList()
            );

            Field<ContactType>(
                "contact",
                 arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "email" }),
                 resolve: context =>
                 {
                     var objectId = (string)context.Arguments["email"];
                     return db.Contacts
                         .Include(p => p.OwnedEvents)
                         .ThenInclude(t => t.Contributions)
                         .Include(t => t.OwnedEvents)
                         .ThenInclude(p => p.Schedules)
                         .Include(p => p.GuestEvents)
                         .ThenInclude(p => p.Event)
                         .FirstOrDefault(c => c.Email == objectId);
                 }
            );
        }
    }
}
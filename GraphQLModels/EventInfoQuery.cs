using GraphQL.Types;
using System.Linq;
using System.Collections.Generic;
using GraphQLModels;
using HackMidwest2018Backend.DatabaseContext;

    public class EventQuery : ObjectGraphType
    {
      public EventQuery()
      {
          var db = new PartyContext();
        Field<EventType>(
          "event",
          resolve: context => db.Events.FirstOrDefault()
        );
      }
    }
using GraphQL.Types;
using HackMidwest2018Backend.DatabaseModels;
using HackMidwest2018Backend.DatabaseContext;
using System.Collections.Generic;

namespace GraphQLModels {
   public class EventType : ObjectGraphType<Event>
    {
      public EventType()
      {
        Field(x => x.EventId);
        Field(x => x.Title, nullable: true);
        Field(x => x.Description, nullable: true);
        Field(x => x.BringAFriend);
        Field(x => x.Website);
        Field(x => x.Location);
        Field(x => x.DressCode);
        Field(x => x.PublicEvent);
        Field(x =>  x.Owner, type: typeof(ContactType));
        Field(x => x.Schedules, type: typeof(ListGraphType<ScheduleType>));
        Field(x => x.Contributions, type: typeof(ListGraphType<ContrubutionType>));
      }
    }
}
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
        Field(x => x.Name, nullable: true);
        Field(x => x.Description, nullable: true);
        Field(x =>  x.Owner, type: typeof(ContactType));
<<<<<<< HEAD
        Field(x => x.Schedules, type: typeof(ListGraphType<ScheduleType>));
=======
>>>>>>> be93bab7a5f9152979b187846f753c3ea32a7220
      }
    }
}
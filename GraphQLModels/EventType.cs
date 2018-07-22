using GraphQL.Types;
using HackMidwest2018Backend.DatabaseModels;
using HackMidwest2018Backend.DatabaseContext;

namespace GraphQLModels {
   public class EventType : ObjectGraphType<Event>
    {
      public EventType()
      {
        Field(x => x.EventId);
        Field(x => x.Name, nullable: true);
        Field(x => x.Description, nullable: true);
        Field(x => x.Owner);
        Field(x => x.Schedules);
      }
    }
}
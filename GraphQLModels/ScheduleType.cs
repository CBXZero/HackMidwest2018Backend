using GraphQL.Types;
using HackMidwest2018Backend.DatabaseModels;

namespace GraphQLModels {
    public class ScheduleType : ObjectGraphType<Schedule>
    {
        public ScheduleType()
        {
            Field(x => x.ScheduleId);
            Field(x => x.EventId);
            Field(x => x.EventDate);
            Field(x => x.Event, type: typeof(EventType));
            Field(x => x.Chosen);
        }
    }
}
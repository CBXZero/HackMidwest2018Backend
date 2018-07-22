using GraphQL.Types;
using HackMidwest2018Backend.DatabaseModels;
using GraphQLModels;

public class EventInputType : InputObjectGraphType
{
    public EventInputType()
    {
        Name = "EventInput";
        Field<IntGraphType>("EventId");
        Field<NonNullGraphType<StringGraphType>>("title");
        Field<StringGraphType>("description");
        Field<NonNullGraphType<ContactInputType>>("owner");
        Field<ListGraphType<ScheduleInputType>>("Schedules");
    }
}

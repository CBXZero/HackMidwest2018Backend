using GraphQL.Types;
using HackMidwest2018Backend.DatabaseModels;
using GraphQLModels;

public class ScheduleInputType : InputObjectGraphType
{
    public ScheduleInputType()
    {
       Name = "ScheduleInput";
       Field<DateGraphType>("EventDate");
       Field<EventInputType>("Event");
       Field<BooleanGraphType>("Chosen");
    }
}

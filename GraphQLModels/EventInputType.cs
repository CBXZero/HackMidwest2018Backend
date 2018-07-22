using GraphQL.Types;
using HackMidwest2018Backend.DatabaseModels;

public class EventInputType : InputObjectGraphType
{
    public EventInputType()
    {
        Name = "EventInput";
        Field<NonNullGraphType<StringGraphType>>("name");
        Field<StringGraphType>("description");
    }
}
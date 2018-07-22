using GraphQL.Types;
using HackMidwest2018Backend.DatabaseModels;
using GraphQLModels;

public class EventGuestInputType : InputObjectGraphType
{
    public EventGuestInputType()
    {
       Name = "EventGuestInput";

       Field<IntGraphType>("EventId");
       Field<IntGraphType>("ContactGuestId");
       Field<BooleanGraphType>("Attending");
    }
}
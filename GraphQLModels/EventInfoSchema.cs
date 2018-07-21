using GraphQL;
using GraphQL.Types;
using GraphQLModels;
using HackMidwest2018Backend.DatabaseContext;
public class EventInfoSchema : Schema
{
    
    public EventInfoSchema()
    {
        PartyContext db = new PartyContext();
        Query = new EventInfoQuery(db);
        RegisterType<EventType>();

        //Mutation = EventInfoMutation();
    }
}
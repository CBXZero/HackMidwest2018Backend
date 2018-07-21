using GraphQL;
using GraphQL.Types;
public class EventInfoSchema : Schema
{
    public EventInfoSchema(IDependencyResolver resolver): base(resolver)
    {
        Query = resolver.Resolve<EventInfoQuery>();
        Mutation = resolver.Resolve<EventInfoMutation>();
    }
}
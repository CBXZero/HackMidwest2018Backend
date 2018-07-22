using GraphQL.Types;
using HackMidwest2018Backend.DatabaseModels;
using GraphQLModels;

public class EventInputType : InputObjectGraphType
{
    public EventInputType()
    {
        Name = "EventInput";
        Field<NonNullGraphType<StringGraphType>>("name");
        Field<StringGraphType>("description");
        Field<NonNullGraphType<ContactInputType>>("owner");
    }
}

public class ContactInputType : InputObjectGraphType
{
    public ContactInputType()
    {
        Name = "ContactInput";
        Field<NonNullGraphType<StringGraphType>>("FirstName");
        Field<StringGraphType>("LastName");
        Field<NonNullGraphType<StringGraphType>>("Email");
    }
} 
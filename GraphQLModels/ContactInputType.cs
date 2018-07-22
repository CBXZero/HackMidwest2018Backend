using GraphQL.Types;
using GraphQLModels;
using HackMidwest2018Backend.DatabaseModels;

public class ContactInputType : InputObjectGraphType
{
    public ContactInputType()
    {
        Name = "ContactInput";
        Field<NonNullGraphType<StringGraphType>>("FirstName");
        Field<NonNullGraphType<StringGraphType>>("LastName");
        Field<NonNullGraphType<StringGraphType>>("Email");
        Field<NonNullGraphType<StringGraphType>>("PhoneNumber");
    }
} 
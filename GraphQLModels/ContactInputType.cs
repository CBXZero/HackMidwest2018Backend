using GraphQL.Types;
using HackMidwest2018Backend.DatabaseModels;

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
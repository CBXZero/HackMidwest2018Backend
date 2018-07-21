using GraphQL.Types;
using HackMidwest2018Backend.DatabaseModels;
using HackMidwest2018Backend.DatabaseContext;

namespace GraphQLModels {
    public class ContactType : ObjectGraphType<Contact>
    {
        public ContactType(PartyContext context)
        {
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field(x => x.PhoneNumber);
            Field(x => x.ContactId);
            Field(x => x.Email);
        }
    }
}
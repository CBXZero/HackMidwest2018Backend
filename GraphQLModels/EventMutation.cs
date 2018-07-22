using GraphQL.Types;
using System.Linq;
using System.Collections.Generic;
using GraphQLModels;
using HackMidwest2018Backend.DatabaseModels;
using HackMidwest2018Backend.DatabaseContext;

namespace HackMidwest2018Backend.GraphQLModels
{
    public class EventMutation : ObjectGraphType
    {
        public EventMutation()
        {
            var db = new PartyContext();

            Field<EventType>(
                "createEvent",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<EventInputType>> {Name = "event"},
                    new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "email"}
                ),
                resolve: context =>
                {
                    var ev = context.GetArgument<Event>("event");
                    var email = context.GetArgument<string>("email");
                    ev.Owner = db.Contacts.FirstOrDefault(c => c.Email == email);
                    db.Events.Add(ev); 
                    db.SaveChanges();
                    return ev;
                });

            Field<ListGraphType<ContrubutionType>>(
                "createContributions",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ListGraphType<ContributionInputType>>> {Name = "contributions"}
                ),
                resolve: context =>
                {
                    var contributions = context.GetArgument<List<Contribution>>("contributions");
                    db.Contributions.AddRange(contributions);
                    db.SaveChanges();
                    return contributions;
                });
            
            Field<ContactType>(
                "createContact",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ContactInputType>> {Name = "contact"}
                ),
                resolve: context => 
                {
                    var ct = context.GetArgument<Contact>("contact");
                    db.Contacts.Add(ct);
                    db.SaveChanges();
                    return ct;
                });
        }
    }
}
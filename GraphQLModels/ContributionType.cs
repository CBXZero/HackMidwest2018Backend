using GraphQL.Types;
using HackMidwest2018Backend.DatabaseModels;
using HackMidwest2018Backend.DatabaseContext;

namespace GraphQLModels {
    public class ContrubutionType : ObjectGraphType<Contribution>
    {
        public ContrubutionType()
        {
            Field(x => x.ContributionId);
            Field(x => x.Contributer, type: typeof(ContactType));
            Field(x => x.Description);
        }
    }
}
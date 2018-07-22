using GraphQL.Types;
using HackMidwest2018Backend.DatabaseModels;
using GraphQLModels;

public class ContributionInputType : InputObjectGraphType
{
    public ContributionInputType()
    {
       Name = "ContributionInput";
       Field<StringGraphType>("Description");
       Field<ContactInputType>("Contributor");
       Field<IntGraphType>("EventId");
    }
}

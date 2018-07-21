using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackMidwest2018Backend.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using GraphQL;
using GraphQL.Types;
using HackMidwest2018Backend.DatabaseModels;

namespace HackMidwest2018Backend.Controllers
{
    [Route("api/[controller]")]
    public class GraphQLController : Controller
    {

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            //if (query == null) { throw new ArgumentNullException(nameof(query)); }
            //var inputs = query.Variables.ToInputs();
            // var executionOptions = new ExecutionOptions
            // {
            //     Schema = new Schema { Query = new EventInfoQuery(new PartyContext()) },
            //     Query = @"query {
            //                 event {
            //                     eventId
            //                 }
            //             }",
            // };

            // var result = await new DocumentExecuter().ExecuteAsync(executionOptions).ConfigureAwait(false);

            // if (result.Errors?.Count > 0)
            // {
            //     return BadRequest(result);
            // }

            var schema = new Schema { Query = new EventQuery() };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
           {
               _.Schema = schema;
               _.Query = @"
                query {
                  event {
                    eventId
                    name
                    description
                  }
                }
              ";
           }).ConfigureAwait(false);

            return Ok(result);
        }
    }
}

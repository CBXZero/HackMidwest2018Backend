using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackMidwest2018Backend.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using GraphQL;
using GraphQL.Types;


namespace HackMidwest2018Backend.Controllers
{
    [Route("api/[controller]")] 
    public class GraphQLController : Controller
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;

        public GraphQLController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            //if (query == null) { throw new ArgumentNullException(nameof(query)); }
            //var inputs = query.Variables.ToInputs();
            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = @"query {
                            event {
                                eventId
                            }
                        }",
            };

            var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}

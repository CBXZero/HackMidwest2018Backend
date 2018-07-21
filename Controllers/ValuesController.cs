using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackMidwest2018Backend.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using GraphQL;
using GraphQL.Types;
using HackMidwest2018Backend.DatabaseModels;
using Newtonsoft.Json.Linq;

namespace HackMidwest2018Backend.Controllers
{
    [Route("graphql")]
    public class GraphQLController : Controller
    {

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GraphQLRequest request)
        {
            var schema = new Schema { Query = new EventQuery() };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
           {
               _.Schema = schema;
               _.Query = request.Query;
               _.Inputs = request.Variables.ToInputs();
           }).ConfigureAwait(false);

            return Ok(result);
        }
    }

    public class GraphQLRequest
    {
        public string OperationName { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}

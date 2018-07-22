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
using HackMidwest2018Backend.GraphQLModels;

namespace HackMidwest2018Backend.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Get(){
            return Ok();
        }
    }
}
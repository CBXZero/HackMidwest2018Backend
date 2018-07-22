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
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace HackMidwest2018Backend.Controllers
{
    [Route("api/[controller]")]
    public class TwilioController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TextModel request)
        {
            const string accountSid = "ACea588e487350e2bb5fd28ffdcc85dff7";
            const string authToken = "3c473054abdcfc803672591536811fba";
            TwilioClient.Init(accountSid, authToken);

            foreach(var friend in request.friendsToSendTo) {
                MessageResource.Create(
                   from: new Twilio.Types.PhoneNumber("5732791195"),
                    to: new Twilio.Types.PhoneNumber(friend),
                   body: $"Your friend would like to invite you to {request.eventName}, please visit https://hackmidwest2018.firebaseapp.com/poll/{request.eventId} to RSVP!"
                );
            }
            
            return Ok();
        }
    }

    public class TextModel {
        public string eventName {get;set;}
        public string eventId {get;set;}
        public List<string> friendsToSendTo {get;set;}
    }
}
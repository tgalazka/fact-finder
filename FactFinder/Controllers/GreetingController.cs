using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FactFinder.Controllers
{
    /// <summary>
    /// Provides a simplistic greeting interface.
    /// </summary>
    public class GreetingController : ApiController
    {
        /// <summary>
        /// Responnds with a simple greeting message.
        /// </summary>
        /// <returns>
        /// {
        ///     "greeting": "Hello, World!"
        /// }
        /// </returns>
        [HttpGet]
        public IHttpActionResult GetGreeting(string name = "")
        {
           GreetingDTO greeting = new GreetingDTO()
            {
                greeting = String.Format("Hello, {0}!", name.Any() ? name : "World") 
            };
            return Ok(greeting);
        }

        private class GreetingDTO
        {
            public string greeting { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace FactFinder.Controllers
{
    /// <summary>
    /// Provides a simplistic greeting interface.
    /// </summary>
    public class GreetingController : ApiController
    {
        /// <summary>
        /// Responds with a simple greeting message.
        /// </summary>
        /// <param name="name">Optional name to include in the greeting.</param>
        /// <returns>GreetingDTO instance.</returns>
        [HttpGet]
        [ResponseType(typeof(GreetingDTO))]
        public IHttpActionResult GetGreeting([Microsoft.AspNetCore.Mvc.FromQuery]string name = "World")
        {
           GreetingDTO greeting = new GreetingDTO()
            {
                greeting = String.Format("Hello, {0}!", name)
            };
            return Ok(greeting);
        }

        private class GreetingDTO
        {
            [Required]
            public string greeting { get; set; }
        }
    }
}

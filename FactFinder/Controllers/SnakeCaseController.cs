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
    /// This a sample that allows for auto-magically generated route bindings 
    /// to be overridden on the class level.
    /// </summary>
    [RoutePrefix("snake_case")]
    public class SnakeCaseController : ApiController
    {

        private static List<SnakeDTO> _snakes = new List<SnakeDTO>()
        {
            new SnakeDTO(1).Name("Boa Constrictor").Country("Belize").Country("Guatemala").Country("Honduras"),
            new SnakeDTO(2).Name("Garter Snake").Country("United States of America").Country("Canada")
        };

        private class SnakeDTO
        {
            [Required] public int id { get; private set; }
            [Required] public string name { get; set; }
            public List<string> countries { get; set; }

            public SnakeDTO(int id) { this.id = id; }
            public SnakeDTO Name(string name) { this.name = name; return this; }
            public SnakeDTO Country(string country)
            {
                if (null == this.countries)
                    this.countries = new List<string>();
                this.countries.Add(country);
                return this;
            }
        }

        /// <summary>
        /// Retrieves a collection of Snakes.
        /// </summary>
        /// <param name="limit">Maximum number of entries to return; must be a positive number.</param>
        /// <param name="offset">Number of entries to skip for pagination; muste be a positive number</param>
        /// <returns>A collection of Snakes</returns>
        [HttpGet]
        [Route("snakes")]
        [ResponseType(typeof(List<SnakeDTO>))]
        public IHttpActionResult GetAllSnakes(
            [Microsoft.AspNetCore.Mvc.FromQuery]int? limit = null, 
            [Microsoft.AspNetCore.Mvc.FromQuery]int? offset = null)
        {
            if (offset.HasValue && offset < 0)
            {
                return BadRequest("Offset must be a positive integer.");
            }

            if (limit.HasValue && limit < 0)
            {
                return BadRequest("Limit must be a positive integer.");
            }

            //Pretend repository call.
            IEnumerable<SnakeDTO> snakes = SnakeRepository.GetSnakes(offset, limit);
            return Ok(snakes);
        }

        private class SnakeRepository
        {
            public static IEnumerable<SnakeDTO> GetSnakes(int? offset, int? limit)
            {
                if (limit.HasValue || offset.HasValue)
                {
                    int off = ((offset ?? 0) >= _snakes.Count) ? -1 : (offset ?? 1) - 1;
                    if (off < 0) return Enumerable.Empty<SnakeDTO>();

                    int lim = ((limit ?? 0) > (_snakes.Count - off)) ? (_snakes.Count - off) : (limit ?? 0);
                    if (lim < 1) return Enumerable.Empty<SnakeDTO>();
                    
                    return _snakes.GetRange(off, lim);
                }
                else
                {
                    return _snakes;
                }
            }
        }
    }
}

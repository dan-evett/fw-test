using fwTest.Dto;
using fwTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace fwTest.Controllers
{
    public class BController : ApiController
    {
        /// <summary>
        /// Gets top 5 movies
        /// Was unsure wether this needed filters or not as the spec mentions returning a bad request response if no filters provided
        /// yet it does not mention any filters
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult TopMovies()
        {
            var movies = new List<MovieDto>();

            using (var context = new fwTestContext())
            {
                var query = from mov in context.Movies                          
                            select new MovieDto()
                            {
                                Id = mov.Id,
                                Title = mov.Title,
                                Genre = mov.Genre,
                                RunningTime = mov.RuningTime,
                                YearOfRelease = mov.YearOfRelease,
                                AverageRating = Math.Round(mov.UserMovieRatings.Average(x => x.Rating) * 2) / 2
                            };
                movies = query.OrderByDescending(s1 => s1.AverageRating).ThenBy(s2 => s2.Title).Take(5).ToList();
            }

            if (movies == null || movies.Count() == 0)
            {
                return NotFound();
            }

            return Ok(movies);
        }
    }
}

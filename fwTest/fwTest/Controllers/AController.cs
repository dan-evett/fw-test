using fwTest.Models;
using fwTest.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace fwTest.Controllers
{
    public class AController : ApiController
    {

        [HttpGet]
        public IHttpActionResult FilterMovies(string title = null, string yearOfRelease = null, string genre = null)
        {
            if(string.IsNullOrWhiteSpace(title) && string.IsNullOrWhiteSpace(yearOfRelease) && string.IsNullOrWhiteSpace(genre))
            {
                return BadRequest();
            }

            var movies = new List<MovieDto>();

            using(var context = new fwTestContext())
            {
                var query = from mov in context.Movies
                            where (mov.Title.Contains(title) || title == null) &&
                             (mov.Genre == genre || genre == null) &&
                             (mov.YearOfRelease == yearOfRelease || yearOfRelease == null)
                            select new MovieDto()
                            {
                                Id = mov.Id,
                                Title = mov.Title,
                                Genre = mov.Genre,
                                RunningTime = mov.RuningTime,
                                YearOfRelease = mov.YearOfRelease,
                                AverageRating = Math.Round(mov.UserMovieRatings.Average(x => x.Rating) * 2) / 2
                         };
                movies = query.OrderByDescending(x => x.AverageRating).ThenBy(x => x.Title).ToList();
            }

            if(movies == null  || movies.Count() == 0)
            {
                return NotFound();
            }

            return Ok(movies);
        }
    }
}

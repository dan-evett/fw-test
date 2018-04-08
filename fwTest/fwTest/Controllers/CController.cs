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
    public class CController : ApiController
    {
        [HttpGet]
        public IHttpActionResult TopMoviesByUser(int id)
        {
            var movies = new List<UserMovieDto>();

            using (var context = new fwTestContext())
            {
                var query = from ratings in context.UserMovieRatings
                            where ratings.UserId == id
                            orderby ratings.Rating descending, ratings.Movie.Title                           
                            select new UserMovieDto()
                            {
                                Id = ratings.Movie.Id,
                                Title = ratings.Movie.Title,
                                Genre = ratings.Movie.Genre,
                                RunningTime = ratings.Movie.RuningTime,
                                YearOfRelease = ratings.Movie.YearOfRelease,
                                UserRating = ratings.Rating,
                                AverageRating = Math.Round(ratings.Movie.UserMovieRatings.Average(x => x.Rating) * 2) / 2
                            };
                movies = query.Take(5).ToList();
            }

            if (movies == null || movies.Count() == 0)
            {
                return NotFound();
            }

            return Ok(movies);
        }
    }
}

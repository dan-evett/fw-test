using fwTest.Dto;
using fwTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace fwTest.Controllers
{
    public class DController : ApiController
    {
        [HttpPost]
        public IHttpActionResult AddRating([FromBody]UserMovieRatingDto request)
        {
            if (request.Rating < 1 || request.Rating > 5)
            {
                return BadRequest();
            }

            using (var context = new fwTestContext())
            {
                var movieExists = context.Movies.Where(w => w.Id == request.MovieId).Count() > 0;
                if (!movieExists)
                {
                    return NotFound();
                }
                var userExists = context.Users.Where(w => w.Id == request.UserId).Count() > 0;
                if (!userExists)
                {
                    return NotFound();
                }
                var ratingEntity = context.UserMovieRatings.Where(w => w.UserId == request.UserId && w.MovieId == request.MovieId).FirstOrDefault();
                if (ratingEntity != null)
                {
                    ratingEntity.Rating = request.Rating;
                    context.Entry(ratingEntity).State = EntityState.Modified;
                }
                else
                {
                    var newEntity = new UserMovieRating()
                    {
                        MovieId = request.MovieId,
                        UserId = request.UserId,
                        Rating = request.Rating
                    };
                    context.UserMovieRatings.Add(newEntity);
                }
                context.SaveChanges();
            }

            return Ok();
        }
    }
}

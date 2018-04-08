using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fwTest.Models
{
    public class UserMovieRating
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int Rating { get; set; }
    }
}
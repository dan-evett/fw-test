using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fwTest.Dto
{
    public class UserMovieRatingDto
    {
        public int UserId { get; set; }

        public int MovieId { get; set; }

        public int Rating { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fwTest.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public string Genre { get; set; }

        public string YearOfRelease { get; set; }

        public int RuningTime { get; set; }

        public virtual ICollection<UserMovieRating> UserMovieRatings { get; set; }
    }
}
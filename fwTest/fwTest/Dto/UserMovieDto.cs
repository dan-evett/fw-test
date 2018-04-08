using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fwTest.Dto
{
    public class UserMovieDto :MovieDto
    {
        public int UserRating { get; set; }
    }
}
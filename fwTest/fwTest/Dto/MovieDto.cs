using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fwTest.Dto
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string YearOfRelease { get; set; }
        public int RunningTime { get; set; }
        public double? AverageRating { get; set; }
    }
}
namespace fwTest.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using fwTest.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<fwTest.Models.fwTestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(fwTest.Models.fwTestContext context)
        {
            context.Movies.AddOrUpdate(x => x.Id,
                new Movie() { Id = 1, Title = "The Shawshank Redemption", YearOfRelease = "1994", Genre = "Drama", RuningTime = 142 },
                new Movie() { Id = 2, Title = "The Godfather", YearOfRelease = "1972", Genre = "Crime", RuningTime = 175 },
                new Movie() { Id = 3, Title = "The Dark Knight", YearOfRelease = "2006", Genre = "Action", RuningTime = 152 },
                new Movie() { Id = 4, Title = "The Godfather: Part II", YearOfRelease = "1974", Genre = "Crime", RuningTime = 202 },
                new Movie() { Id = 5, Title = "Pulp Fiction", YearOfRelease = "1994", Genre = "Crime", RuningTime = 154 },
                new Movie() { Id = 6, Title = "Schindler's List", YearOfRelease = "1993", Genre = "History", RuningTime = 195 },
                new Movie() { Id = 7, Title = "The Lord of the Rings: The Return of the King", YearOfRelease = "2003", Genre = "Fantasy", RuningTime = 201 },
                new Movie() { Id = 8, Title = "The Good, the Bad and the Ugly", YearOfRelease = "1966", Genre = "Western", RuningTime = 178 },
                new Movie() { Id = 9, Title = "Inception", YearOfRelease = "2010", Genre = "Fantasy", RuningTime = 148 },
                new Movie() { Id = 10, Title = "Fight Club", YearOfRelease = "1999", Genre = "Drama", RuningTime = 139 }
                );

            context.Users.AddOrUpdate(x => x.Id,
                new User() { Id = 1 },
                new User() { Id = 2 },
                new User() { Id = 3 },
                new User() { Id = 4 },
                new User() { Id = 5 }
                );

            context.UserMovieRatings.AddOrUpdate(x => x.Id,
                new UserMovieRating() { Id = 1, MovieId = 1, UserId = 1, Rating = 5 },
                new UserMovieRating() { Id = 2, MovieId = 1, UserId = 2, Rating = 4 },
                new UserMovieRating() { Id = 3, MovieId = 1, UserId = 3, Rating = 4 },
                new UserMovieRating() { Id = 4, MovieId = 2, UserId = 2, Rating = 1 },
                new UserMovieRating() { Id = 5, MovieId = 3, UserId = 2, Rating = 2 },
                new UserMovieRating() { Id = 6, MovieId = 4, UserId = 4, Rating = 3 },
                new UserMovieRating() { Id = 7, MovieId = 5, UserId = 4, Rating = 4 },
                new UserMovieRating() { Id = 8, MovieId = 6, UserId = 5, Rating = 5 },
                new UserMovieRating() { Id = 9, MovieId = 7, UserId = 5, Rating = 5 },
                new UserMovieRating() { Id = 10, MovieId = 10, UserId = 5, Rating = 3 }
                );
            
        }
    }
}
namespace DVDLibraryService.Migrations
{
    using DVDLibraryService.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DVDLibraryService.Models.DVDLibraryEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DVDLibraryService.Models.DVDLibraryEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Ratings.AddOrUpdate(
                    r => r.RatingName,
                    new Rating { RatingName = "G" },
                    new Rating { RatingName = "PG" },
                    new Rating { RatingName = "PG-13" },
                    new Rating { RatingName = "R" }
                );

            context.SaveChanges();

            context.Dvds.AddOrUpdate(
                m => m.Title,
                new Dvd
                {
                    Title = "A really great EF Tale.",
                    ReleaseYear = 2021,
                    DirectorName = "Drew McPherson",
                    RatingId = context.Ratings.First(r => r.RatingName == "PG").RatingId,
                    Notes = "So many migrations."
                }
            );
        }
    }
}

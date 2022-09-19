using DVDLibraryService.Data.Interfaces;
using DVDLibraryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDLibraryService.Data.Repositories
{

    public class DVDRepositoryMock : IDVDRepository
    {


        private static List<Rating> _ratings = new List<Rating>
        {
            new Rating { RatingId = 1, RatingName = "G"},
            new Rating { RatingId = 2, RatingName = "PG"},
            new Rating { RatingId = 3, RatingName = "PG-13"},
            new Rating { RatingId = 4, RatingName = "R"}
        };

        private static List<Dvd> _dvds = new List<Dvd>
        {
            new Dvd {DvdId = 1, Title = "A Good Tale", ReleaseYear = 2015, DirectorName = "Sam Jones",
                RatingId = 1, Notes = "This is a really good tale"},

            new Dvd {DvdId = 2, Title = "A Great Tale", ReleaseYear = 2012, DirectorName = "Joe Smith",
                RatingId = 2, Notes = "This is a great tale"},

            new Dvd {DvdId = 3, Title = "A Fabulous Tale", ReleaseYear = 2011, DirectorName = "Mary Shields",
                RatingId = 3, Notes = "This is a really fabulous tale"},

            new Dvd {DvdId = 4, Title = "A Terrific Tale", ReleaseYear = 2009, DirectorName = "Amanda Jones",
                RatingId = 4, Notes = "This is a really terrific tale"},

            new Dvd {DvdId = 5, Title = "An Amazing Tale", ReleaseYear = 2007, DirectorName = "John Goodman",
                RatingId = 1, Notes = "This is an amazing tale"}

        };

       

        public void CreateDvd(Dvd dvd)
        {
            throw new NotImplementedException();
        }

        public void DeleteDvd(int dvd)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> GetAllDvds()
        {
            foreach (Dvd d in _dvds)
            {
                d.Rating = _ratings.Where(r => r.RatingId.Equals(d.RatingId)).FirstOrDefault();
            }
            return _dvds;
        }

        public Dvd GetDvdById(int dvdId)
        {
             return _dvds.FirstOrDefault(d => d.DvdId == dvdId);
        }

        public List<Dvd> GetDvdsByDirector(string director)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> GetDvdsByRating(string rating)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> GetDvdsByYear(string releaseYear)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> GetDvdsByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public void UpdateDvd(Dvd dvd)
        {
            throw new NotImplementedException();
        }
    }
}
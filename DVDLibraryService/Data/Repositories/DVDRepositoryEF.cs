using DVDLibraryService.Data.Interfaces;
using DVDLibraryService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DVDLibraryService.Data.Repositories
{
    public class DVDRepositoryEF : IDVDRepository
    {
        public void CreateDvd(Dvd dvd)
        {
            using (var context = new DVDLibraryEntities())
            {
                context.Dvds.Add(dvd);
                context.SaveChanges();
            }
        }

        public List<Dvd> GetAllDvds()
        {
            using (var context = new DVDLibraryEntities())
            {
                List<Dvd> allDvds = context.Dvds.ToList();

                foreach (Dvd d in allDvds)
                {
                    d.RatingId = d.Rating.RatingId;
                }

                return allDvds;
            }
        }

        public Dvd GetDvdById(int dvdId)
        {
            using (var context = new DVDLibraryEntities())
            {
                Dvd found = context.Dvds.SingleOrDefault(d => d.DvdId == dvdId);

                found.RatingId = found.Rating.RatingId;

                return found;
            }
        }

        public List<Dvd> GetDvdsByDirector(string director)
        {
            if (string.IsNullOrEmpty(director))
            {
                return null;
            }

            using (var context = new DVDLibraryEntities())
            {
                List<Dvd> dvds = context.Dvds.Where(d => d.DirectorName.Contains(director)).ToList();

                foreach (Dvd d in dvds)
                {
                    d.RatingId = d.Rating.RatingId;
                }

                if (dvds.Any())
                {
                    return dvds;
                }

                return null;
            }
        }

        public List<Dvd> GetDvdsByRating(string rating)
        {
            if (string.IsNullOrEmpty(rating))
            {
                return null;
            }

            using (var context = new DVDLibraryEntities())
            {
                var result = context.Ratings.Where(r => r.RatingName == rating).FirstOrDefault();

                if (result == null)
                {
                    return null;
                }

                List<Dvd> dvds = context.Dvds.Where(d => d.Rating.RatingId.Equals(result.RatingId)).ToList();

                if (dvds.Any())
                {
                    return dvds;
                }

                return null;
            }
        }

        public List<Dvd> GetDvdsByYear(string releaseYear)
        {
            if (string.IsNullOrEmpty(releaseYear))
            {
                return null;
            }

            using (var context = new DVDLibraryEntities())
            {
                List<Dvd> dvds = context.Dvds.Where(d => d.ReleaseYear.ToString().Contains(releaseYear)).ToList();

                foreach (Dvd d in dvds)
                {
                    d.RatingId = d.Rating.RatingId;
                }

                if (dvds.Any())
                {
                    return dvds;
                }

                return null;
            }
        }

        public List<Dvd> GetDvdsByTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return null;
            }

            using (var context = new DVDLibraryEntities())
            {
                List<Dvd> dvds = context.Dvds.Where(d => d.Title.Contains(title)).ToList();

                foreach (Dvd d in dvds)
                {
                    d.RatingId = d.Rating.RatingId;
                }

                if (dvds.Any())
                {
                    return dvds;
                }

                return null;
            }
        }


        public void UpdateDvd(Dvd dvd)
        {
            var context = new DVDLibraryEntities();

            Dvd d = context.Dvds.Where(x => x.DvdId == dvd.DvdId).First();

            d.Title = dvd.Title;
            d.ReleaseYear = dvd.ReleaseYear;
            d.DirectorName = dvd.DirectorName;
            d.RatingId = dvd.RatingId;
            d.Notes = dvd.Notes;

            context.SaveChanges();
        }

        public void DeleteDvd(int dvdId)
        {
            using (var context = new DVDLibraryEntities())
            {
                Dvd dvd = context.Dvds.SingleOrDefault(d => d.DvdId == dvdId);

                if (dvd != null)
                {
                    context.Dvds.Remove(dvd);
                    context.SaveChanges();
                }
            }
        }
    }
}
using DVDLibraryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibraryService.Data.Interfaces
{
    public interface IDVDRepository
    {
        Dvd GetDvdById(int dvdId);
        List<Dvd> GetAllDvds();
        List<Dvd> GetDvdsByDirector(string director);
        List<Dvd> GetDvdsByRating(string rating);
        List<Dvd> GetDvdsByTitle(string title);
        List<Dvd> GetDvdsByYear(string releaseYear);
        void CreateDvd(Dvd dvd);
        void DeleteDvd(int dvdId);
        void UpdateDvd(Dvd dvd);
    }
}

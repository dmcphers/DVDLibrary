using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDLibraryService.Models
{
    public class Dvd
    {
        public int DvdId { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string DirectorName { get; set; }
        public int RatingId { get; set; }
        public string Notes { get; set; }

        public virtual Rating Rating { get; set; }
    }
}
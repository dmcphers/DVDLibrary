using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DVDLibraryService.Models
{
    public class DVDLibraryEntities : DbContext
    {
        public DVDLibraryEntities()
       : base("DVDLibraryEF")
        {
        }

        public DbSet<Dvd> Dvds { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}
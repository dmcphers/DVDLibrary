using DVDLibraryService.Data;
using DVDLibraryService.Data.Interfaces;
using DVDLibraryService.Data.Repositories;
using DVDLibraryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DVDLibraryService.Controllers
{
    public class DVDController : ApiController
    {
        
        //Create a new DVD
        [Route("dvds/")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Create(Dvd dvd)
        {
            var repo = RepositoryFactory.Create();

            repo.CreateDvd(dvd);
            return Created($"/dvd/{dvd.DvdId}", dvd);
        }


        //Get all DVDs
        [Route("dvds/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllDvds()
        {

            var repo = RepositoryFactory.Create();

            List<Dvd> dvds = repo.GetAllDvds();

            return Ok(dvds);
        }

        //Get DVD by Id
        [Route("dvds/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int id)
        {
            var repo = RepositoryFactory.Create();

            Dvd found = repo.GetDvdById(id);

            if (found == null)
            {
                return NotFound();
            }

            return Ok(found);
        }


        //Get by title
        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByTitle(string title)
        {
            var repo = RepositoryFactory.Create();

            List<Dvd> dvds = repo.GetDvdsByTitle(title);

            if (dvds == null)
            {
                return NotFound();
            }
            return Ok(dvds);
        }


        //Get by year
        [Route("dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByYear(string releaseYear)
        {
            var repo = RepositoryFactory.Create();

            List<Dvd> dvds = repo.GetDvdsByYear(releaseYear);

            if (dvds == null)
            {
                return NotFound();
            }
            return Ok(dvds);
        }

        //Get by director
        [Route("dvds/director/{director}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByDirector(string director)
        {
            List<Dvd> dvds = RepositoryFactory.Create().GetDvdsByDirector(director);
           
            if (dvds == null)
            {
                return NotFound();
            }

            else
            {
                return Ok(dvds);
            }
        }

        //Get by rating
        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByRating(string rating)
        {
            var repo = RepositoryFactory.Create();

            List<Dvd> dvds = repo.GetDvdsByRating(rating);

            if (dvds == null)
            {
                return NotFound();
            }

            else
            {
                return Ok(dvds);
            }
        }


        //Update/Edit DVD
        [Route("dvds/{id}")]
        [AcceptVerbs("PUT")]
        public void Update(int id, Dvd dvd)
        {
            var repo = RepositoryFactory.Create();
            dvd.DvdId = id;
 
            repo.UpdateDvd(dvd);
        }


        //Delete Dvd
        [Route("dvds/{id}")]
        [AcceptVerbs("DELETE")]
        public void Delete(int id)
        {
            var repo = RepositoryFactory.Create();

            Dvd dvd = repo.GetDvdById(id);

            repo.DeleteDvd(id);
        }
    }
}

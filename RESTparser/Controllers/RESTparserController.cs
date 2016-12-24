using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTparser.Models;

namespace RESTparser.Controllers
{
    public class RESTparserController : ApiController
    {
        public IEnumerable<Artist> GetAllArtists()
        {
            return Functions.GetAllArtists();
        }

        public Artist GetArtist(string artist)
        {
            var searchArtist = Functions.ShowArtistsByFullname(artist);
            if (searchArtist == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No Artist name {0}", artist)),
                    ReasonPhrase = "Artist Not Found"
                };

                throw new HttpResponseException(resp);
            }
            
            return searchArtist;
        }

        [HttpPost]
        public void CreateArtist([FromBody]Artist artist)
        {
            Functions.InsertArtistIntoDb(artist);
        }

        [HttpDelete]
        public void DeleteArtist(string artist)
        {
            Functions.DeleteArtistByName(artist);
        }
    }
}

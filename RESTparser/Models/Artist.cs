using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RESTparser.Models
{
    public class Artist
    {
        [Key]
        public string Name { get; set; }
        public List<string> TopTracks { get; set; }
        public List<string> Genres { get; set; }
        public List<string> TopAlbums { get; set; }
        public List<string> SimilarArtists { get; set; }
        public string Bio { get; set; }
    }
}
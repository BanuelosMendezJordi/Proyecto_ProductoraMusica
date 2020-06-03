using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Productora.Web.Models
{
    public class SongArtist
    {
        public int Id { get; set; }
        public int SongId { get; set; }
        [ForeignKey("SongId")]
        public Song Song { get; set; }
        public int ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; }
        public ICollection<Song> Songs { get; set; }
        public ICollection<Artist> Artists { get; set; }
    }
}
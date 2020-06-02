using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Productora.Web.Models
{
    public class Song
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Título")]
        public string SongTitle { get; set; }
        [Display(Name = "Duración")]
        public decimal SongLength { get; set; }
        [Display(Name = "Género")]
        public string SongGenre { get; set; }
        //public byte[] SongSample { get; set; }
        public string SongLanguage { get; set; }
        public Album Album { get; set; }
        public Artist Artist { get; set; }
        public ICollection<Album> Albums { get; set; }
        public ICollection<Artist> Artists { get; set; }
    }
}
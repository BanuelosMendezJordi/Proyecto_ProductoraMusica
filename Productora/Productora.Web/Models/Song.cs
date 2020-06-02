using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int AlbumId { get; set; }
        [ForeignKey("AlbumId")]
        public Album Album { get; set; }
        public Artist Artist { get; set; }
        public ICollection<Album> Albums { get; set; }
        public ICollection<Artist> Artists { get; set; }
    }
}
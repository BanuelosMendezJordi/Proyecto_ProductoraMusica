using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Productora.Web.Models
{
    public class Album
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Título")]
        [MaxLength(70)]
        public string AlbumTitle { get; set; }
        [Display(Name ="Descripción")]
        [MaxLength(250)]
        public string Description { get; set; }
        [Display(Name = "Fecha de Lanzamiento")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name ="Género")]
        [MaxLength(30)]
        public string AlbumGenre { get; set; }
        
        /*[DisplayName("Número de Canciones")]
        public int AlbumSongs { get; set; }*/
        [Display(Name ="Portada")]
        public byte[] AlbumCover { get; set; }
        public Artist Artist { get; set; }
        public ICollection<Artist> Artists { get; set; }
    }
}
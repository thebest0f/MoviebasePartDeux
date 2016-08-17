using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MoviebasePartDeux.Models
{
    public class Movie
    {

        [Key]
        public int MovieId { get; set; }

        public string MovieName { get; set; }
        public string MovieDirector { get; set; }
        public int MovieYear { get; set; }
        public string MovieDesc { get; set; }
        public DateTime CreationDate { get; set; }

        [ForeignKey("Genre")]
        public int GenreRefId { get; set; }
        

        public virtual Genre Genre { get; set; }
    }
}
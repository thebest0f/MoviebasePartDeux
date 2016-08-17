﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MoviebasePartDeux.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        public string GenreName { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
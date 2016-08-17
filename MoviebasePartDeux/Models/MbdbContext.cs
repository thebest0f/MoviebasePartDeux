using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MoviebasePartDeux.Models
{
    public class MbdbContext : DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }

    }

    
}
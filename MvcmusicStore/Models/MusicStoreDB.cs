using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcmusicStore.Models
{
    public class MusicStoreDB : DbContext
    {
        public MusicStoreDB()
            : base("name=DefaultConnection")
        { 
        }

        public IDbSet<Album> Albums { get; set; }

        public IDbSet<Genre> Genres { get; set; }

        public IDbSet<Artist> Artists { get; set; }
    }
}
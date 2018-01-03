using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NiseWorld.Models
{
    public class DBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Password> Passwords { get; set; }
        public DbSet<Repost> Reposts { get; set; }
        public DbSet<Folover> Folovers { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Coment> Coments { get; set; }

    }
   
}
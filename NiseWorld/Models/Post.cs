using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NiseWorld.Models
{
    public class Post
    {
        [Key]
        public int IdPost { get; set; }
        public string Сaption { get; set; }
        public string Text { get; set; }
        public int? IdUser { get; set; }    
        public User User { get; set; }
        public DateTime Time { get; set; }
        public List<Like> Likes { get; set; }
        public List<Repost> Reposts { get; set; }
        public List<Picture> Pictures { get; set; }
        public List<Coment> Coments { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NiseWorld.Models
{
    public class ForPost
    {

        public int IdForPost { get; set; }
        public int? IdPost { get; set; }
        public Post Post { get; set; }
        public int? IdUser { get; set; }
        public User User { get; set; }
        public int KolLikeUsera { get; set; }
        public int KolPostUsera { get; set; }
        public int? IdRePost { get; set; }
        public List<Repost> Reposts { get; set; }
        public List<Like> Likes { get; set; }
        public List<Picture> Pictures { get; set; }
        public List<Coment> Coments { get; set; }
        public List<User> UserComents { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NiseWorld.Models
{
    public class ForUserAdmin
    {
        public int IdForUserAdmin { get; set; }
        public int? IdUsers { get; set; }
        public User Users { get; set; }
        public int IdUser { get; set; }
        //имя пользователя
        public string Name { get; set; }
        // отчество
        public string Patronymic { get; set; }
        // отчество
        public string Surname { get; set; }
        // возраст
        public int Age { get; set; }
        public string Address { get; set; }
        public List<Post> Posts { get; set; }
        public List<Post> Reposts { get; set; }
        public List<Post> LikesPost { get; set; }
        public Role Roles { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

    }
}
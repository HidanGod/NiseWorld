using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace NiseWorld.Models
{
    public class User
    {
        // ID пользователя
        
        [Key]
        public int IdUser { get; set; }
        //имя пользователя
        public string Name { get; set; }
        // отчество
        public string Patronymic { get; set; }
        // отчество
        public string Surname { get; set; }
        // возраст
        public int Age { get; set; }
        // адрес      
        public string Address { get; set; }
        public DateTime Time { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public int? IdRole { get; set; }
        public Role Role { get; set; }
        public List<Post> Posts { get; set; }
        public List<Like> Likes { get; set; }
        public List<Repost> Reposts { get; set; }
        public List<Coment> Coments { get; set; }

    }
}
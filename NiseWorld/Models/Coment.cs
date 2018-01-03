using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NiseWorld.Models
{
    public class Coment
    {
        [Key]
        public int IdComent { get; set; }
        public int? IdPost { get; set; }
        public int? IdUser { get; set; }
        public User user { get; set; }
        public string Text { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime Time { get; set; }
    }
}
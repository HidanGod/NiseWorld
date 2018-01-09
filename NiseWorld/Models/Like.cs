using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NiseWorld.Models
{
    public class Like
    {
        [Key]
        public int IdLike { get; set; }
        public int? IdPost { get; set; }     
        public int? IdUser { get; set; }
        public bool liked { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime Time { get; set; }
    }
}
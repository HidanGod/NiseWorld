using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NiseWorld.Models
{
    public class Repost
    {
        [Key]
        public int IdRepost { get; set; }
        public int? IdPost { get; set; }
        public int? IdUser { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime Time { get; set; }
    }
}
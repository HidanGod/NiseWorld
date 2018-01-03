using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public DateTime Time { get; set; }
    }
}
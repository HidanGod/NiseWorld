using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Text { get; set; }
        public DateTime Time { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NiseWorld.Models
{
    public class Folover
    {
        [Key]
        public int IdFolover { get; set; }
        public int IdUserFolover { get; set; }
        public int IdUserpursued { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime Time { get; set; }
    }
}
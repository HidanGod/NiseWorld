using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public DateTime Date { get; set; }
    }
}
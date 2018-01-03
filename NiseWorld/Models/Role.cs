using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NiseWorld.Models
{
    public class Role
    {
        [Key]
        public int IdRole { get; set; }
        public string role { get; set; }
    }
}
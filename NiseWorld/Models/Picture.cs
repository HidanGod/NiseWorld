using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NiseWorld.Models
{
    public class Picture
    {
        [Key]
        public int IdPicture { get; set; }
        public string Name { get; set; } // название картинки
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public int? IdPost { get; set; }

    }
}
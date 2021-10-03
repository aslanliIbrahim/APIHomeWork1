using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIHomeWork1.Models
{
    public class Book:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Writer { get; set; }

        [Required]
        public string SharedDate { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string ShortAbout {get; set; }
    }
}

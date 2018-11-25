using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        public string Name { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Stock Number")]
        public int NumberInStock { get; set; }

        [Display(Name = "Number avalable")]
        public int NumberAvailable { get; set; }

        public int GenreId { get; set; }

        [Display(Name = "Genre")]
        public Genre Genre { get; set; }
    }
}
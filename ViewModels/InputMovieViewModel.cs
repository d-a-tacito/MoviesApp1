using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Models;

namespace MoviesApp.ViewModels
{
    public class InputMovieViewModel
    {
        // public InputMovieViewModel()
        // {
        //     this.Actors = new HashSet<Actor>();
        // }
        public string Title { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        //public virtual ICollection<Actor> Actors { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Models
{
    public class Actor
    {
        // public Actor()
        // {
        //     this.Movies = new HashSet<Movie>();
        // }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        //public virtual ICollection<Movie> Movies { get; set; }
    }
}
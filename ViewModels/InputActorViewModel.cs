﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Models;

namespace MoviesApp.ViewModels;

public class InputActorViewModel
{
    // public InputActorViewModel()
    // {
    //     this.Movies = new HashSet<Movie>();
    // }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
    //public virtual ICollection<Movie> Movies { get; set; }
}
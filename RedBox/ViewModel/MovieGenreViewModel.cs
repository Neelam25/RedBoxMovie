using RedBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedBox.ViewModel
{
    public class MovieGenreViewModel
    {
        public MovieModel Movie { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
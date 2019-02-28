using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RedBox.Models;
using RedBox.ViewModel;

namespace RedBox.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var movieGenremodel = new MovieGenreViewModel
            {
                Movie = new MovieModel(),
                Genres = genres
            };
            return View("MovieFormView",movieGenremodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MovieModel movie)
        {
            if(!ModelState.IsValid)
            {
                var movieGenreViewModel = new MovieGenreViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("MovieFormView", movieGenreViewModel);
            }
            if(movie.ID == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.SingleOrDefault(m=>m.ID == movie.ID);
                movieInDb.Name = movie.Name;
                movieInDb.ReleasedDate = movie.ReleasedDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.GenreId = movie.GenreId;
            }
            try
            {
                _context.SaveChanges();

            }
            catch(DbEntityValidationException dbe)
            {
                Console.WriteLine(dbe);
            }
            return RedirectToAction("Index","Movie");
        }
        // GET: Movie
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }
        public ActionResult Edit(int id)
        {
            var genres = _context.Genres.ToList();
            var movieGenremodel = new MovieGenreViewModel
            {
                Movie = _context.Movies.SingleOrDefault(m => m.ID == id),
                Genres = genres
            };
            return View("MovieFormView", movieGenremodel);
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.ID == id);
            if (movie == null) return HttpNotFound();
            return View(movie);
        }
        public IEnumerable<MovieModel> GetMovieModels()
        {
            return new List<MovieModel>
            {
                new MovieModel{ID=1,Name = "Shrek"},
                new MovieModel{ID=2,Name = "Die hard"},
                new MovieModel{ID=3,Name = "Cars"},

            };
        }
    }
}
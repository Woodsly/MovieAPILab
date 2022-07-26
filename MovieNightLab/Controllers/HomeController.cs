using Microsoft.AspNetCore.Mvc;
using MovieNightLab.Models;
using System.Diagnostics;

namespace MovieNightLab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public MovieDAL movieDAL = new MovieDAL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]//run when you first go to page
        public IActionResult MovieSearch()
        {
            return View();
        }
        [HttpPost]//run when you submit your form
        public IActionResult MovieSearch(string title)
        {
            MovieModel movie = movieDAL.GetMovie(title);
            return View(movie);
        }

        [HttpGet]//run when you first go to page
        public IActionResult MovieNight()
        {
            return View();
        }
        [HttpPost]//run when you submit your form
        public IActionResult MovieNight(string title1, string title2, string title3)
        {
            List<MovieModel> movies = new List<MovieModel>();
            movies.Add(movieDAL.GetMovie(title1));
            movies.Add(movieDAL.GetMovie(title2));
            movies.Add(movieDAL.GetMovie(title3));
            return View(movies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
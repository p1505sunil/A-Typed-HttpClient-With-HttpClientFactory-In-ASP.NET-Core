using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieFinder.Models;

namespace MovieFinder.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieDetailsClient _movieDetailsClient;

        public HomeController(IMovieDetailsClient movieDetailsClient)
        {
            _movieDetailsClient = movieDetailsClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Submit(MovieDetailModel model)
        {
            var movieDetail = await _movieDetailsClient.GetMovieDetailsAsync(model.Title);

            return View("Index", movieDetail);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

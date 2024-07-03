using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Webappdevops.Models;
using Webappdevops.Repository;

namespace Webappdevops.Controllers
{
    public class HomeController : Controller
    {
// private readonly ILogger<HomeController> _logger;

        IPostRepository postRepository;

        public HomeController( IPostRepository _postRepository)
        {
           // _logger = logger;
            postRepository = _postRepository;
        }

        //public HomeController(IPostRepository _postRepository)
        //{
        //    postRepository = _postRepository;
        //}

        public IActionResult Index()
        {
            var model = postRepository.GetPosts();
            return View(model);
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
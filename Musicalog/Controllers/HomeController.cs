using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Musicalog.Models;
using WebApi.Interfaces;

namespace Musicalog.Controllers
{
    public class HomeController : Controller
    {
        private IValuesController apiValuesController;

        public HomeController(IValuesController apiValuesController)
        {
            this.apiValuesController = apiValuesController;
        }

        public IActionResult Index()
        {
            IEnumerable<string> values = apiValuesController.Get().Value;
            return View(values);
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

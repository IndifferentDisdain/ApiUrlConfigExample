using ApiUrlConfigExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace ApiUrlConfigExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<ConfigBaseSettings> _configBaseSettings;
        private readonly IOptions<ConfigDetailSettings> _configDetailSettings;


        public HomeController(
            ILogger<HomeController> logger, 
            IOptions<ConfigBaseSettings> configBaseSettings, 
            IOptions<ConfigDetailSettings> configDetailSettings)
        {
            _logger = logger;
            _configBaseSettings = configBaseSettings;
            _configDetailSettings = configDetailSettings;
        }

        public string GetListURL(bool useDetailSettings = false)
        {
            if (useDetailSettings)
                return _configDetailSettings.Value.GetListURL;

            return $"{_configBaseSettings.Value.BaseURL}Foo/";
        }

        public string GetDetailsURL(int id, bool useDetailSettings = false)
        {
            if (useDetailSettings)
                return $"{_configDetailSettings.Value.GetDetailsURL}{id}";

            return $"{_configBaseSettings.Value.BaseURL}Foo/Details/{id}";
        }

        public IActionResult Index()
        {
            return View();
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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurveyManagement.Models;

namespace SurveyManagement.Controllers
{
    public class ViewController : Controller
    {
        private readonly Repository<Models.Domain.Survey> _rep;
        public ViewController(Repository<Models.Domain.Survey> rep)
        {
            _rep = rep;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_rep.Get());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

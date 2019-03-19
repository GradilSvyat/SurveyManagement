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
        //private readonly SurveyController _survey;
        public ViewController(Repository<Models.Domain.Survey> rep)
        {
            _rep = rep;
        }
        //public async Task<IActionResult> Index()
        //{

        //    return View(await _rep.GetAllServeys());
        //}

        [HttpGet]
        public IActionResult Index()
        {
            return View(_rep.Get());
        }

        [HttpGet]
        public IActionResult Survey(int id)
        {
            ViewBag.x = _rep.FindQuestionsWithAnswers(id);
            return View( _rep.FindById(id));
        }

        public IActionResult Create()
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

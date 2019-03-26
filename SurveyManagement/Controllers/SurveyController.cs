using Microsoft.AspNetCore.Mvc;
using SurveyManagement.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyManagement.Controllers
{

    public class SurveyController : Controller
    {
        private readonly Repository<Models.Domain.Survey> _rep;

        public SurveyController(Repository<Models.Domain.Survey> rep)
        {
            _rep = rep;
        }

        public IActionResult Survey(int id)
        {
            ViewBag.survey = _rep.FindById(id);
            return View(_rep.FindQuestionsWithAnswers(id));
        }

        [HttpGet]
        public IActionResult CreateSurvey()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSurvey(Models.Domain.Survey new_survey)
        {
            var listNames = _rep.GetAll();
            foreach (var a in listNames)
            {
                if (new_survey.Name == a.Name)
                {
                    ModelState.AddModelError("Name", "Опросник с таким названием уже существует");
                }
            }
            if (ModelState.IsValid)
            {
                _rep.Create(new_survey);
                return Redirect(String.Format("~/View/Survey/{0}", new_survey.Id));
            }
            return View();
        }



        [Route("survey")]
        public ActionResult<IList<Models.Domain.Survey>> Get()
        {
            return new OkObjectResult(_rep.GetAll());
        }

        [HttpGet("/survey/{id}")]
        public ActionResult GetSingleSurvey(int id)
        {
            return new OkObjectResult(_rep.FindById(id));
        }

        [HttpGet("/QuestionsWithAnswers/{id}")]
        public ActionResult GetSingleQuestionsWithAnswers(int id)
        {
            return new OkObjectResult(_rep.FindQuestionsWithAnswers(id));
        }

        //[HttpPut("/survey/{id}")]
        //public ActionResult EditSurvey(int id)
        //{
        //    var a = _rep.FindById(id);

        //    return new OkObjectResult(_rep.(id));
        //}

        [HttpPost]
        public ActionResult Create(Models.Domain.Survey item)
        {
            _rep.Create(item);

            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var surveys = _rep.FindById(id);
            _rep.Remove(surveys);
            return Ok();
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using SurveyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyManagement.Controllers
{

    public class SurveyController : ControllerBase
    {
        private readonly Repository<Models.Domain.Survey> _rep;

        public SurveyController(Repository<Models.Domain.Survey> rep)
        {
            _rep = rep;
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

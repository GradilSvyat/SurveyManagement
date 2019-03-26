using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyManagement.Models.Repositories;

namespace SurveyManagement.Controllers
{
    public class AnswerController : Controller
    {
            private readonly AnswerRepository _rep;

            public AnswerController(AnswerRepository rep)
            {
                _rep = rep;
            }

            // GET: Answer
            public ActionResult Index()
        {
            return View();
        }

        // GET: Answer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateAnswer(int id)
        {
            Models.Domain.Answer answer = new Models.Domain.Answer()
            {
                QuestionId = id
            };
            return View(answer);
        }

        [HttpPost]
        public IActionResult CreateAnswer(Models.Domain.Answer new_answer)
        {
            if (ModelState.IsValid)
            {
                _rep.Create(new_answer);
                return Redirect(String.Format("~/Survey/Survey/{0}", _rep.GetSurveyId(new_answer.QuestionId)));
            }
            return View();
        }

        // POST: Answer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Answer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Answer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Answer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Answer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
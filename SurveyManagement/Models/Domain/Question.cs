using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyManagement.Models.Domain
{
    public class Question
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; private set; }
        [Required(ErrorMessage = "Вы не ввели текст вопроса")]
        [Display(Name = "Текст вопроса")]
        public string Text { get; set; }
        [Display(Name = "Текст коментария")]
        public string Comment { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int SurveyId { get; set; }

        public Question(string text, string comment, int id, int surveyId)
        {
            SurveyId = surveyId;
            Id = id;
            Comment = comment;
            Text = text;
        }
        public Question()
        {
        }


    }
}

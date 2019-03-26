using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyManagement.Models.Domain
{
    public class Answer
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; private set; }
        [HiddenInput(DisplayValue = false)]
        public int QuestionId { get; set; }
        [Required(ErrorMessage = "Вы не ввели текст ответа")]
        [Display(Name = "Текст ответа")]
        public string Text { get; set; }

        public Answer(int questionId, string text)
        {
            QuestionId = questionId;
            Text = text;
        }
        public Answer()
        {
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyManagement.Models.Domain
{
    public class Survey
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; private set; }
        [Required(ErrorMessage = "Вы не ввели название опросника")]
        [StringLength(100,ErrorMessage = "Название опросника не должно превышать 100 символов")]
        [Display(Name = "Название опросника")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Вы не ввели имя создателя")]
        [StringLength(40, ErrorMessage = "Имя создателя не должно превышать 40 символов")]
        [Display(Name = "Имя создателя")]
        public string Creator { get; set; }
        [HiddenInput(DisplayValue = false)]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public Survey()
        {
            Date = DateTime.Now;
        }
    }
}

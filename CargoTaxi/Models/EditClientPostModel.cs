using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace CargoTaxi.Models
{
    public class EditClientPostModel
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Имя")]
        //[StringLength(20, ErrorMessage = "Значение {0} должно содержать символов не менее: {2}.", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Фамилия")]
        //[StringLength(30, ErrorMessage = "Значение {0} должно содержать символов не менее: {2}.", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]        
        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber,ErrorMessage ="Введите номер телефона")]
        public string PhoneNumber { get; set; }       
    }
}
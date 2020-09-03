using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoTaxi.Models
{
    public class EditOrderPostModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Number { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}"
           , ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string StartTime { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string StartAdress { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string FinishAdress { get; set; }
       
        public int? CarCategoryId { get; set; }
        //public CarCategoryViewModel Category { get; set; }
        public int? CarId { get; set; }

        //[Required(ErrorMessage = "Поле должно быть установлено")]
       // public SelectList CarRegisterNumbers { get; set; }
        public string ClientId { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage ="Введите верно номер телефона")]
        [DataType(DataType.PhoneNumber)]
        public string ClientPhoneNumber { get; set; }
        //public SelectList Categories { get; set; }
    }
}
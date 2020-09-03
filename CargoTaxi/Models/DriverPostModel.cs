using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoTaxi.Models
{
    public class DriverPostModel
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Введите номер телефона")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Введите адрес электронной почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string DriverLicense { get; set; }       

        public IList<CarViewModel> Cars { get; set; }
        public bool IsActiveDriver { get; set; }

        public DriverPostModel()
        {           
            Cars = new List<CarViewModel>();
        }
    }
}
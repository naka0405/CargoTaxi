using CargoTaxi.CustomValidation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CargoTaxi.Models
{
    public class CreateOrderPostModel
    {        
        [DataType(DataType.Date)]        
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}"
            , ApplyFormatInEditMode = true)]        
        [ValidOrderDate]       
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [ValidOrderTime]
        public string StartTime { get; set; }

        [MaxLength(100, ErrorMessage = "Значение {0} должно содержать не более {1} символов.")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string StartAdress { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string FinishAdress { get; set; }

        public int? CarCategoryId { get; set; }      
        public string ClientId { get; set; }
        public SelectList Categories { get; set; }
    }
}


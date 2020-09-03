using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoTaxi.Models
{
    public class MessageViewModel
    {        
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string PhoneNumber { get; set; }
        //public string Email { get; set; }

        public string Number { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
       
        public string StartAdress { get; set; }
        public string FinishAdress { get; set; }

        //[HiddenInput(DisplayValue = false)]
        //public int? CarCategoryId { get; set; }
        public string Category { get; set; }
        //public CarViewModel Car { get; set; }
        //[HiddenInput(DisplayValue = false)]
        //public string ClientId { get; set; }
        public UserViewModel Client { get; set; }
    }
}
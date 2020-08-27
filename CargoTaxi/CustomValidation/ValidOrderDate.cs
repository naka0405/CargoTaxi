using System;
using System.ComponentModel.DataAnnotations;

namespace CargoTaxi.CustomValidation
{
    public class ValidOrderDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validCtx)
        {
            DateTime _deliveryDate = Convert.ToDateTime(value);
            DateTime _currentDate = DateTime.Today;
            var twoWeek = new TimeSpan(14, 0, 0, 0);
            if (_currentDate > _deliveryDate||_deliveryDate>_currentDate+twoWeek)
            {
                return new ValidationResult
                    ("Дата заказа указана не верно");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace CargoTaxi.CustomValidation
{
    public class ValidOrderTime : ValidationAttribute
    {
        //protected override ValidationResult IsValid1(object value, ValidationContext validCtx)
        //{
        //    var time = (string)value;
        //    if (time.Length == 4)
        //    {
        //        var hourStr = time.Take(2).ToString();
        //        var minStr = time.Substring(2);

        //        for (int i = 0; i < time.Length; i++)
        //        {
        //            if (!int.TryParse(time[i].ToString(), out int num))
        //            {
        //                return new ValidationResult
        //                 ("Время указано не верно");
        //            }
        //        }
        //        if (int.Parse(hourStr) > 24 || int.Parse(hourStr) < 0 || int.Parse(minStr) > 60 || int.Parse(minStr) < 0)
        //        {
        //            return new ValidationResult
        //                 ("Время указано не верно");
        //        }
        //        else
        //        {
        //            return ValidationResult.Success;
        //        }
        //    }
        //    else
        //    {
        //        return new ValidationResult
        //                 ("Время указано не верно");
        //    }
        //}

        protected override ValidationResult IsValid(object value, ValidationContext validCtx)
        {
            var time = (string)value;           
            
            if (time.Length != 5)
            {
                return new ValidationResult
                         ("Время указано не верно");
            }
            var validTime = time.Remove(2, 1);
            var sign = time.Substring(2).Take(1).FirstOrDefault().ToString();
            var hourStr = time.Substring(0, 2);
            var minStr = time.Substring(3);
            if (sign.Contains(":") || sign.Contains("-") || sign.Contains("_"))
            {

                for (int i = 0; i < validTime.Length; i++)
                {
                    if (!int.TryParse(validTime[i].ToString(), out int num))
                    {
                        return new ValidationResult
                         ("Время указано не верно");
                    }
                }
                if (int.Parse(hourStr) > 24 || int.Parse(hourStr) < 0 || int.Parse(minStr) > 60 || int.Parse(minStr) < 0)
                {
                    return new ValidationResult
                         ("Время указано не верно");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
                return new ValidationResult
                            ("Время указано не верно");

            }
    }

}

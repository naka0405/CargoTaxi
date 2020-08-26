using CargoTaxi.CustomValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var time = "15:69";

            if (time.Length != 5)
            {

            }
            var validTime = time.Remove(2, 1);
            var sign = time.Substring(2).Take(1).ToString();
            var hourStr = time.Take(2).ToString();
            var minStr = time.Substring(2);
            if (!sign.Contains(":") && !sign.Contains("-") && !sign.Contains("/") && !sign.Contains("_"))
            {
                Console.WriteLine("Время указано не верно");
            }

            //for (int i = 0; i < validTime.Length; i++)
            //{
            //    if (!int.TryParse(time[i].ToString(), out int num))
            //    {
            //        return new ValidationResult
            //         ("Время указано не верно");
            //    }
            //}

            if (int.Parse(hourStr) > 24 || int.Parse(hourStr) < 0 || int.Parse(minStr) > 60 || int.Parse(minStr) < 0)
            {
                Console.WriteLine("Время указано не верно");
            }
            else
            {
                Console.WriteLine("!!!");
            }

        }
    }
    }

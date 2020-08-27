using CargoTaxi.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoTaxi.CustomValidation
{
    public class NewOrderFAValidation : AbstractValidator<CreateOrderPostModel>
    {
        public NewOrderFAValidation()
        {
            var week = new TimeSpan(7, 0, 0, 0);
            var msg = "Ошибка в поле {PropertyName}: значение {PropertyValue}";
            RuleFor(x => x.Date)
                    .GreaterThan(x => DateTime.Now + week)
                    .LessThan(x => DateTime.Now)
                    .WithMessage(msg);// ("Вы можете сделать заказ не болле, чем на неделю вперед.\nДата должна быть больше или равна сегодняшней дате");


            //           RuleFor(c => c.FirstName)
            //.Must(c => c.All(Char.IsLetter)).WithMessage(msg);

            //           RuleFor(c => c.LastName)
            //           .Must(c => c.All(Char.IsLetter)).WithMessage(msg);

            //           RuleFor(c => c.Age)
            //            .GreaterThan(14).WithMessage(msg)
            //            .LessThan(180).WithMessage(msg);
            RuleFor(t => t.StartTime)
                     .Must(TimeValid)
                     .WithMessage("Введите правильно время");

            //RuleFor(c => c.Phone)
            //.Must(IsPhoneValid).WithMessage(msg)
            //.Length(12).WithMessage("Длина должна быть от {MinLength} до {MaxLength}. Текущая длина: {TotalLength}");

            //RuleFor(c => c.Email)
            //.NotNull().WithMessage(msg)
            //.EmailAddress();
        }

        private bool IsPhoneValid(string phone)
        {
            return !(!phone.StartsWith("+79")
            || !phone.Substring(1).All(c => Char.IsDigit(c)));
        }

        private bool TimeValid(string startTime)
        {


            return !startTime.Equals(default(DateTime));
        }
    }
}


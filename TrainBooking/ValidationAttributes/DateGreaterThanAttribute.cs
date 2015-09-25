using System;
using System.ComponentModel.DataAnnotations;

namespace TrainBooking.ValidationAttributes
{
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private string DepatureDateTime { get; set; }
        private string ArrivalDateTime { get; set; }

        public DateGreaterThanAttribute(string depatureDateTime, string arrivalDateTime)
        {
            DepatureDateTime = depatureDateTime;
            ArrivalDateTime = arrivalDateTime;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime depatureDateTime = (DateTime)validationContext.ObjectType.GetProperty(DepatureDateTime).GetValue(validationContext.ObjectInstance, null);
            DateTime arrivalDateTime = (DateTime)validationContext.ObjectType.GetProperty(ArrivalDateTime).GetValue(validationContext.ObjectInstance, null);

            if (arrivalDateTime > depatureDateTime)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Дата прибытия должна быть позже даты отправления");
        }
    }
}
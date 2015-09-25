using System.ComponentModel.DataAnnotations;

namespace TrainBooking.ValidationAttributes
{
    public class NotEqualToAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return false;
        }
    }
}
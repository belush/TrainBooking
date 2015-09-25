using System.ComponentModel.DataAnnotations;
using TrainBooking.BL.Logic;
using TrainBooking.BL.Logic.Interfaces;
using TrainBooking.DAL;
using TrainBooking.DAL.Repositories;
using TrainBooking.DAL.Repositories.Implementations;

namespace TrainBooking.ValidationAttributes
{
    public class UniqueStationAttribute : ValidationAttribute
    {
        private readonly IStationLogic _stationLogic;

        private string LastStation { get; set; }

        public UniqueStationAttribute(string lastStation)
        {
            LastStation = lastStation;
            var context = new TrainBookingContext();
            _stationLogic = new StationLogic(new StationRepository(context));
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int startStation = (int)value;
            int endStation = (int)validationContext.ObjectType.GetProperty(LastStation).GetValue(validationContext.ObjectInstance, null);

            if (endStation != startStation)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Начальная станция должна отличаться от конечной");
            }
        }
    }
}
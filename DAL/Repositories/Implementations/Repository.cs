namespace TrainBooking.DAL.Repositories
{
    public class Repository
    {
        protected readonly TrainBookingContext db = new TrainBookingContext();

        public Repository(TrainBookingContext context)
        {
            db = context;
        }
    }
}

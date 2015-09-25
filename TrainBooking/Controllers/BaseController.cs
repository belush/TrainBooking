using System.Web.Mvc;
using TrainBooking.Filters;

namespace TrainBooking.Controllers
{
    [InitializeSimpleMembership]
    public class BaseController : Controller
    {
    }
}
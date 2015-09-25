using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBooking.DAL.EntityMetaData;

namespace TrainBooking.DAL.Entities
{
    [MetadataType(typeof(UserMetaData))]
    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MidName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}

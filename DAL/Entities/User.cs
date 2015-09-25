using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainBooking.DAL.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        [Display(Name = "Код")]
        public int UserId { get; set; }

        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Отчество")]
        public string MidName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        public DateTime BirthDate { get; set; }
    }
}

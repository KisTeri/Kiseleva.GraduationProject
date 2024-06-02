using Kiseleva.GraduationProject.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Kiseleva.GraduationProject.Entities
{
    public class Address : ISoftDelete
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите область(республика, край, автономный округ)")]
        [RegularExpression(@"^[a-zA-Z\s]+|[а-яА-Я\s]+$", ErrorMessage = "Допустимы только буквенные символы")]
        public string Region { get; set; } //республика, край, область, автономный округ
        public string? District { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите город(поселок, деревню)")]
        [RegularExpression(@"^[a-zA-Z\s]+|[а-яА-Я\s]+$", ErrorMessage = "Допустимы только буквенные символы")]
        public string Settlement { get; set; } // город, поселок, деревня

        [Required(ErrorMessage = "Пожалуйста, введите улицу")]
        [RegularExpression(@"^[a-zA-Z\s]+|[а-яА-Я\s]+$", ErrorMessage = "Допустимы только буквенные символы")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите номер дома")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Допустимы только цифры")]
        public string Building { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Допустимы только цифры")]
        public string? Apartment { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Допустимы только цифры")]
        public string? Index { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]+|[а-яА-Я\s]+$", ErrorMessage = "Допустимы только буквенные символы")]
        public string? KindOfAddress { get; set; } //фактический или юридический(у одной организации 2 адреса) 

        public Person? Person { get; set; }

        //public int? OrganisationId { get; set; }
        public Organisation? Organisation { get; set; }

        public CZN? CZN { get; set; }


        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }

        public Address()
        {

        }
    }
}

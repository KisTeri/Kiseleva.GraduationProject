using Kiseleva.GraduationProject.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Kiseleva.GraduationProject.Entities
{
    public class DocumentOfPerson : ISoftDelete
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите серию паспорта")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Допустимы только цифры")]
        public string Series { get; set; } // спросить, какие данные подает организация на ученика

        [Required(ErrorMessage = "Пожалуйста, введите номер паспорта")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Допустимы только цифры")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите кем выдан паспорт")]
        [RegularExpression(@"^[a-zA-Z]+|[а-яА-Я]+$", ErrorMessage = "Допустимы только буквенные символы")] ///??????
        public string IssuedBy { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите когда выдан паспорт")]
        [RegularExpression(@"(0[1-9]|[12][0-9]|3[01])[.](0[1-9]|1[012])[.](19|20)\d\d", ErrorMessage = "Введите дату в правильном формате через . с использоанием цифр")]
        public DateOnly IssuedWhen { get; set; } /////////

        [Required(ErrorMessage = "Пожалуйста, введите номер СНИЛС")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Допустимы только цифры")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Длина должна быть 11 символов")]
        public string SNILS { get; set; }


        public Person Person { get; set; }
        public KindOfDocument KindOfDocument { get; set; }

        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }

        public DocumentOfPerson()
        {

        }
    }
}

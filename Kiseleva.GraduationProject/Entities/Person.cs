using Kiseleva.GraduationProject.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Kiseleva.GraduationProject.Entities
{
    public class Person : ISoftDelete
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите фамилию")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 50 символов")]
        [RegularExpression(@"^[a-zA-Z]+|[а-яА-Я]+$", ErrorMessage = "Допустимы только буквенные символы")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите имя")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 50 символов")]
        [RegularExpression(@"^[a-zA-Z]+|[а-яА-Я]+$", ErrorMessage = "Допустимы только буквенные символы")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите отчество")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 50 символов")]
        [RegularExpression(@"^[a-zA-Z]+|[а-яА-Я]+$", ErrorMessage = "Допустимы только буквенные символы")]
        public string MiddleName { get; set; }

        public string FullName
        {
            get
            {
                return LastName + " " + FirstName + " " + MiddleName;
            }
        }

        //[Required(ErrorMessage = "Пожалуйста, введите дату рождения")]
        [RegularExpression(@"(0[1-9]|[12][0-9]|3[01])[.](0[1-9]|1[012])[.](19|20)\d\d", ErrorMessage = "Введите дату в правильном формате через . с использоанием цифр")]
        public DateOnly? DateOfBirth { get; set; }

        //[Required(ErrorMessage = "Пожалуйста, введите номер телефона")]
        [StringLength(12, MinimumLength = 11, ErrorMessage = "Длина должна быть от 11 до 12 символов. Начните с +7 или 8")]
        //[RegularExpression(@"^\d+$", ErrorMessage = "Допустимы только цифры")]        
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите роль человека в учебном центре")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 50 символов")]
        [RegularExpression(@"^[a-zA-Z]+|[а-яА-Я]+$", ErrorMessage = "Допустимы только буквенные символы")]
        public string? KindOfPerson { get; set; }

        //[Required(ErrorMessage = "Пожалуйста, введите должность")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 50 символов")]
        [RegularExpression(@"^[a-zA-Z]+|[а-яА-Я]+$", ErrorMessage = "Допустимы только буквенные символы")]
        public string? Position { get; set; }

        public int? AddressId { get; set; }
        //public int? OrganisationId { get; set; }

        public Address? Address { get; set; }
        public ICollection<DocumentOfPerson>? DocumentsOfPerson { get; set; }
        public ICollection<Contract>? Contracts { get; set; }
        public Organisation? Organisation { get; set; }
        public CZN? CZN { get; set; }
        public ICollection<File>? Files { get; set; }

        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }

        public Person()
        {

        }
    }
}

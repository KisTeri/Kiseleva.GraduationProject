using Kiseleva.GraduationProject.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kiseleva.GraduationProject.Entities
{
    public class Contract : ISoftDelete
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите номер договора")]
        public string Number { get; set; }
        public DateTime DateOfSigning { get; set; }
        /*public string? ValidityPeriod { get; set; }*/ //Мб удалить
        public DateTime? DateOfBeginning { get; set; }
        /*public DateTime? DateOfEnding { get; set; }*/  //Мб удалить
		/*public string? SigningBody { get; set; }*/ //Мб удалить
		public int ProgramOfEducationId { get; set; }
        public int? PersonId { get; set; }
        
        public Organisation? Organisation { get; set; }
        public ProgramOfEducation ProgramOfEducation { get; set; }
        public Person? Person { get; set; }


        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }

        public Contract()
        {

        }

        //public static explicit operator Contract(Person v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

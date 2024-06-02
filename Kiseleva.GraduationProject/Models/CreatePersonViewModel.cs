using Kiseleva.GraduationProject.Entities;
using System.ComponentModel.DataAnnotations;

namespace Kiseleva.GraduationProject.Models
{
    public class CreatePersonViewModel
    {
        public int Id { get; set; }
        //public string LastName { get; set; }
        //public string FirstName { get; set; }
        //public string MiddleName { get; set; }
        //public DateTime? DateOfBirth { get; set; }
        //public string? PhoneNumber { get; set; }
        //public string Region { get; set; } 
        //public string? District { get; set; }
        //public string Settlement { get; set; } 
        //public string Street { get; set; }
        //public string Building { get; set; }
        //public string? Apartment { get; set; }
        //public string? KindOfAddress { get; set; }
        //public string Kind { get; set; }
        public string Series { get; set; } 
        public string Number { get; set; }
        public string IssuedBy { get; set; }
        public DateOnly IssuedWhen { get; set; } /////////
        public string SNILS { get; set; }

        //public int PersonId { get; set; }
        //public int KindOfDocumentId { get; set; }
        public Person Person { get; set; }

        //public int SelectedDocumentId { get; set; }
        public KindOfDocument KindOfDocument { get; set; }
    }
}
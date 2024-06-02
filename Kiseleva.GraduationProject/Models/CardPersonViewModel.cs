using Kiseleva.GraduationProject.Entities;

namespace Kiseleva.GraduationProject.Models
{
    public class CardPersonViewModel
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
		public string FullName
		{
			get
			{
				return LastName + " " + FirstName + " " + MiddleName;
			}
		}
		public DateOnly? DateOfBirth { get; set; } /////////
        public string? PhoneNumber { get; set; }

		public string Series { get; set; }
		public string Number { get; set; }
		public string IssuedBy { get; set; }
		public DateOnly IssuedWhen { get; set; } ////////
		public string SNILS { get; set; }
        //public string Kind { get; set; }

        public int AddressId { get; set; }

		public Address? Address { get; set; }
		public ICollection<DocumentOfPerson>? DocumentsOfPerson { get; set; }

		public ICollection<Entities.File>? Files { get; set; }
		//public ICollection<Contract> Contracts { get; set; }

	}
}
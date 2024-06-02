using Kiseleva.GraduationProject.Interfaces;

namespace Kiseleva.GraduationProject.Entities
{
    public class CZN : ISoftDelete
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? ShortName { get; set; }
        public string? Email { get; set; }
        public string? RS { get; set; }
        public string? BankForRS { get; set; }
        public string? KS { get; set; }
        public string? BIK { get; set; }
        public string? INN { get; set; }
        public string? KPP { get; set; }
        public string? OGRN { get; set; }
        public string? DocumentOfOrganisation { get; set; }
        public string? PhoneNumber { get; set; }

        public ICollection<Address>? Addresses { get; set; }

        public int? PersonId { get; set; }
        public Person? Person { get; set; }

        public ICollection<File>? Files { get; set; }

        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }

        public CZN()
        {

        }
    }
}

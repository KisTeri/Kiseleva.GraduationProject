using Kiseleva.GraduationProject.Interfaces;

namespace Kiseleva.GraduationProject.Entities
{
    public class ProgramOfEducation : ISoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }

        public string PriceInWords { get; set; }
        public string HoursAmount { get; set; }
        public string EducationLength { get; set; }


        public ICollection<Contract> Contracts { get; set; }
        public KindOfEducation KindOfEducation { get; set; } // уточнить, может ли одна и та же программа подходить для вовышения и обучения с нуля

        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }

        public ProgramOfEducation()
        {

        }
    }
}

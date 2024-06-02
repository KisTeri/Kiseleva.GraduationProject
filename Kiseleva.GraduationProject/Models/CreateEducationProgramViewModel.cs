using Kiseleva.GraduationProject.Entities;

namespace Kiseleva.GraduationProject.Models
{
    public class CreateEducationProgramViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string PriceInWords { get; set; }
        public string HoursAmount { get; set; }
        public string EducationLength { get; set; }
        public KindOfEducation KindOfEducation { get; set; }

    }
}
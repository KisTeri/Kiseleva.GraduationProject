using Kiseleva.GraduationProject.Entities;

namespace Kiseleva.GraduationProject.Models
{
    public class IndexHomeViewModel
    {
        public List<Person>? Persons { get; set; }
        public List<Organisation>? Organisations { get; set; }
        public List<CZN>? CZNs { get; set; }
    }
}

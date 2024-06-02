using Kiseleva.GraduationProject.Entities;

namespace Kiseleva.GraduationProject.Models
{
    public class IndexPersonViewModel
    {
        public Person Person { get; set; }
        public ICollection<Person> Persons { get; set; }
    }
}

using Kiseleva.GraduationProject.Entities;

namespace Kiseleva.GraduationProject.Models
{
	public class CardWithFiles
	{
        public int PersonId { get; set; }
        public Person CardPerson { get; set; }
        public ICollection<Entities.File> Files { get; set; }
    }
}

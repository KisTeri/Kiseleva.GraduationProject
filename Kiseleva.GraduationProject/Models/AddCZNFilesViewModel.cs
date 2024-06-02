using Kiseleva.GraduationProject.Entities;

namespace Kiseleva.GraduationProject.Models
{
	public class AddCZNFilesViewModel
    {
        public int CZNId { get; set; }
        public CZN CZN { get; set; }
        public ICollection<Entities.File> Files { get; set; }
    }
}

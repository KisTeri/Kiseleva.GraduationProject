using Kiseleva.GraduationProject.Entities;

namespace Kiseleva.GraduationProject.Models
{
	public class AddOrganisationFilesViewModel
	{
        public int OrganisationId { get; set; }
        public Organisation Organisation { get; set; }
        public ICollection<Entities.File> Files { get; set; }
    }
}

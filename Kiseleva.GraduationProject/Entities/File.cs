using Kiseleva.GraduationProject.Interfaces;

namespace Kiseleva.GraduationProject.Entities
{
    public class File : ISoftDelete
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }

        public int? PersonId { get; set; }
        public Person? Person { get; set; }

        public int? OrganisationId { get; set; }
        public Organisation? Organisation { get; set; }

        public int? CZNId { get; set; }
        public CZN? CZN { get; set; }

        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }

        public File()
        {
            
        }
    }
}

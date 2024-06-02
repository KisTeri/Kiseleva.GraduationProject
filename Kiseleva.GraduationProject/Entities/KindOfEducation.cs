using Kiseleva.GraduationProject.Interfaces;

namespace Kiseleva.GraduationProject.Entities
{
    public class KindOfEducation : ISoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ProgramOfEducation> ProgramsOfEducation { get; set; }

        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }

        public KindOfEducation()
        {

        }
    }
}

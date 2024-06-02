using Kiseleva.GraduationProject.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Kiseleva.GraduationProject.Entities
{
    public class KindOfDocument : ISoftDelete
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите вид документа")]
        public string Kind { get; set; }

        public ICollection<DocumentOfPerson> DocumentsOfPerson { get; set; }

        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }

        public KindOfDocument()
        {

        }
    }
}

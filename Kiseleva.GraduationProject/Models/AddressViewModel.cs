using Kiseleva.GraduationProject.Entities;
using System.ComponentModel.DataAnnotations;

namespace Kiseleva.GraduationProject.Models
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        public string Region { get; set; } //республика, край, область, автономный округ
        public string? District { get; set; }
        public string Settlement { get; set; } // город, поселок, деревня
        public string Street { get; set; }
        public string Building { get; set; }
        public string? Apartment { get; set; }
        public string? Index { get; set; }
        public string? KindOfAddress { get; set; } //фактический или юридический(у одной организации 2 адреса) 



        public int? OrganisationId { get; set; } /////?????
        public Organisation? Organisation { get; set; } /////?????
    }
}

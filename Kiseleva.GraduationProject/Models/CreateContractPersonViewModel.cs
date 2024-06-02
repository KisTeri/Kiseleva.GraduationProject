using Kiseleva.GraduationProject.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Kiseleva.GraduationProject.Models
{
    public class CreateContractPersonViewModel
    {
        //public int PersonId { get; set; }
        //public int ContractId { get; set; }
        [Required(ErrorMessage = "Введите номер договора")]
        public string ContractNumber { get; set; }
        //public DateTime ContractDateOfSigning { get; set; }

        [Required(ErrorMessage = "Выберите программу обучения")]
        public int SelectedProgramId { get; set; }
    }
}
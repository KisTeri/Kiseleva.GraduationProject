using Kiseleva.GraduationProject.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Kiseleva.GraduationProject.Models
{
    public class CreateContractOrganisationViewModel /// Дополнить
    {
        [Required(ErrorMessage = "Введите номер договора")]
        public string ContractNumber { get; set; }

        [Required(ErrorMessage = "Выберите дату начала действия договора")]
        public DateTime DateOfBeginning { get; set; }

        [Required(ErrorMessage = "Выберите программу обучения")]
        public int SelectedProgramId { get; set; }

        //public int OrganisationId { get; set; }
    }
}
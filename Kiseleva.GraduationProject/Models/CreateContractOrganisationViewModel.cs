using Kiseleva.GraduationProject.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Kiseleva.GraduationProject.Models
{
    public class CreateContractOrganisationViewModel /// ���������
    {
        [Required(ErrorMessage = "������� ����� ��������")]
        public string ContractNumber { get; set; }

        [Required(ErrorMessage = "�������� ���� ������ �������� ��������")]
        public DateTime DateOfBeginning { get; set; }

        [Required(ErrorMessage = "�������� ��������� ��������")]
        public int SelectedProgramId { get; set; }

        //public int OrganisationId { get; set; }
    }
}
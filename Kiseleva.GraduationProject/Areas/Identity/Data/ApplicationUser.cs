using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Kiseleva.GraduationProject.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    [RegularExpression(@"^[a-zA-Z]+|[а-яА-Я]+$", ErrorMessage = "Допустимы только буквенные символы")]
    public string LastName { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    [RegularExpression(@"^[a-zA-Z]+|[а-яА-Я]+$", ErrorMessage = "Допустимы только буквенные символы")]
    public string FirstName { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    [RegularExpression(@"^[a-zA-Z]+|[а-яА-Я]+$", ErrorMessage = "Допустимы только буквенные символы")]
    public string MiddleName { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(12)")]
    public string PhoneNumber { get; set; }
}


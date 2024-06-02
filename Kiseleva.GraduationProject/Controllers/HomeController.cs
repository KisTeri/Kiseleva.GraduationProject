using Kiseleva.GraduationProject.Data;
using Kiseleva.GraduationProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace Kiseleva.GraduationProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult IndexAfterSearch(string searchString)
        //{

        //    var all = from m in _context.Persons.Where(p => p.DateOfBirth != null)
        //                 .Include(m => m.Organisation)
        //                 .Include(m => m.CZN)
        //                 select m;

        //    //var org = from m in _context.Organisations
        //    //             select m;

        //    //var Czn = from m in _context.CZNs
        //    //          select m;

        //    //var vm = new IndexHomeViewModel
        //    //{
        //    //    Persons = people.ToList(),
        //    //    Organisations = org.ToList(),
        //    //    CZNs = Czn.ToList(),
        //    //};

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        if (!(all = all.Where(p => p.LastName.Contains(searchString) || p.FirstName.Contains(searchString) || p.MiddleName.Contains(searchString) || p.PhoneNumber.Contains(searchString))).IsNullOrEmpty())
        //        {
        //            return View(all.ToList());
        //        }

        //        if (!(all = all.Where(p => p.Organisation.FullName.Contains(searchString) || p.Organisation.ShortName.Contains(searchString) || p.Organisation.PhoneNumber.Contains(searchString))).IsNullOrEmpty())
        //        {
        //            return View(all);
        //        }

        //        if (!(all = all.Where(p => p.CZN.FullName.Contains(searchString) || p.CZN.ShortName.Contains(searchString) || p.CZN.PhoneNumber.Contains(searchString))).IsNullOrEmpty())
        //        {
        //            return View(all);
        //        }
        //    }
        //    return View(all);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
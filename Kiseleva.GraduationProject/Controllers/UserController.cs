using iText.Svg.Renderers.Path.Impl;
using Kiseleva.GraduationProject.Data;
using Kiseleva.GraduationProject.Entities;
using Kiseleva.GraduationProject.Interfaces;
using Kiseleva.GraduationProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using File = Kiseleva.GraduationProject.Entities.File;
using X.PagedList;
using KvalExample.Constants;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.AspNetCore.Identity;
using Kiseleva.GraduationProject.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.Net;
using iText.Commons.Actions.Contexts;
using Kiseleva.GraduationProject.Repository;


namespace Kiseleva.GraduationProject.Controllers
{
    public class UserController : Controller
    {
        private readonly AuthDbContext _authDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        [BindProperty]
		public CardPersonViewModel CardViewModel { get; set; }

        public UserController(AuthDbContext authDbContext, UserManager<ApplicationUser> userManager)
        {
            _authDbContext = authDbContext;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? page)
        {
            var users = _userManager.Users.Select(c => new UsersViewModel()
            {
                Id = c.Id,
                LastName = c.LastName,
                FirstName = c.FirstName,
                MiddleName = c.MiddleName,
                Role = string.Join(",", _userManager.GetRolesAsync(c).Result.ToArray())
            }).ToList();

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(users.ToPagedList(pageNumber, pageSize));
        }

        public async Task<IActionResult> UserPersonalInformation(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var viewModel = new UserPersonalInformation
            {
                Id = id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Role = string.Join(",", _userManager.GetRolesAsync(user).Result.ToArray()),
                UserName = user.UserName
            };
            return View(viewModel);

        }

        public async Task<IActionResult> Edit(string id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
                return View(user);
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, string email, string lastName, string firstName, string middleName, string phoneNumber, string userName)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                if (!string.IsNullOrEmpty(lastName))
                    user.LastName = lastName;
                else
                    ModelState.AddModelError("", "Фамилия не может быть пустой!");

                if (!string.IsNullOrEmpty(firstName))
                    user.FirstName = firstName;
                else
                    ModelState.AddModelError("", "Имя не может быть пустым!");

                if (!string.IsNullOrEmpty(middleName))
                    user.MiddleName = middleName;
                else
                    ModelState.AddModelError("", "Отчество не может быть пустым!");

                if (!string.IsNullOrEmpty(phoneNumber))
                    user.PhoneNumber = phoneNumber;
                else
                    ModelState.AddModelError("", "Номер телефона не может быть пустым!");

                if (!string.IsNullOrEmpty(userName))
                    user.UserName = userName;
                else
                    ModelState.AddModelError("", "Логин не может быть пустым!");

                if (!string.IsNullOrEmpty(email))
                    user.Email = email;
                else
                    ModelState.AddModelError("", "Эл.почта не может быть пустой!");

                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(phoneNumber) && !string.IsNullOrEmpty(middleName) && !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
                {
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                    else
                        Errors(result);
                }
            }
            else
                ModelState.AddModelError("", "Пользователь не найден");
            return View(user);
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = _authDbContext.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(_authDbContext.Users.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["UserDeleted"] = "Ошибка удаления пользователя";
                return RedirectToAction("Index");
            }
        }
    }
}
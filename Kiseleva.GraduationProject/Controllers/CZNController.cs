using Kiseleva.GraduationProject.Data;
using Kiseleva.GraduationProject.Entities;
using Kiseleva.GraduationProject.Interfaces;
using Kiseleva.GraduationProject.Models;
using Kiseleva.GraduationProject.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace Kiseleva.GraduationProject.Controllers
{
	public class CZNController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly ICZNRepository _CZNRepository;
		public CZNController(ApplicationDbContext context, ICZNRepository CZNRepository)
        {
			_context = context;
			_CZNRepository = CZNRepository;
		}

		[HttpGet]
		public async Task<IActionResult> Index(string searchString, string currentFilter, string sortOrder, int? page)
		{
			ViewBag.CurrentSort = sortOrder;

			ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

			if (searchString != null)
			{
				page = 1;
			}
			else
			{
				searchString = currentFilter;
			}

			ViewData["CurrentFilter"] = searchString;

			var organisations = from p in _context.CZNs
                                select p;

			if (!String.IsNullOrEmpty(searchString))
			{
				organisations = organisations.Where(p => p.FullName.Contains(searchString) || p.ShortName.Contains(searchString) || p.Email.Contains(searchString));
			}

			switch (sortOrder)
			{
				case "name_desc":
					organisations = organisations.OrderByDescending(s => s.FullName);
					break;
				default:
					organisations = organisations.OrderBy(s => s.FullName);
					break;
			}

			int pageSize = 10;
			int pageNumber = (page ?? 1);
			return View(organisations.ToPagedList(pageNumber, pageSize));
		}

		[HttpGet]
		public async Task<IActionResult> InformationAboutCZN(int id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var CZN = await _CZNRepository.GetByIdAsync(id);

			if (CZN == null)
			{
				return NotFound();
			}

			var viewModel = new InformationAboutCZNViewModel
			{
				Id = id,
				FullName = CZN.FullName,
				ShortName = CZN.ShortName,
				Email = CZN.Email,
				RS = CZN.RS,
				BankForRS = CZN.BankForRS,
				KS = CZN.KS,
				BIK = CZN.BIK,
				INN = CZN.INN,
				KPP = CZN.KPP,
				OGRN = CZN.OGRN,
				DocumentOfOrganisation = CZN.DocumentOfOrganisation,
				PhoneNumber = CZN.PhoneNumber,
				Addresses = CZN.Addresses.Where(x => x.CZN.Id == id).ToList(),
				Person = CZN.Person,
				Files = CZN.Files.Where(x => x.CZN.Id == id).ToList(),
			};
			return View(viewModel);

		}

		[HttpGet]
		public async Task<IActionResult> CreateCZN()
		{
			var createCZNViewModel = new CreateCZNViewModel();
			return View(createCZNViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCZN(CreateCZNViewModel createCZNViewModel)
		{
			if (ModelState.IsValid)
			{
				var CZN = new CZN()
				{
					FullName = createCZNViewModel.FullName,
					ShortName = createCZNViewModel.ShortName,
					Email = createCZNViewModel.Email,
					RS = createCZNViewModel.RS,
					BankForRS = createCZNViewModel.BankForRS,
					KS = createCZNViewModel.KS,
					BIK = createCZNViewModel.BIK,
					INN = createCZNViewModel.INN,
					KPP = createCZNViewModel.KPP,
					OGRN = createCZNViewModel.OGRN,
					DocumentOfOrganisation = createCZNViewModel.DocumentOfOrganisation,
					PhoneNumber = createCZNViewModel.PhoneNumber,
				};
				
				_CZNRepository.Add(CZN);
				_CZNRepository.Save();

				return RedirectToAction("Index");
			}
			else
			{
				ModelState.AddModelError("", "Ошибка добавления нового ЦЗН");
			}

			return View(createCZNViewModel);
		}

		[HttpGet]
		public async Task<IActionResult> EditCZN(int id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var CZN = await _CZNRepository.GetByIdAsync(id);

			if (CZN == null) return NotFound();

			var editCZNVM = new EditCZNViewModel
			{
				FullName = CZN.FullName,
				ShortName = CZN.ShortName,
				Email = CZN.Email,
				RS = CZN.RS,
				BankForRS = CZN.BankForRS,
				KS = CZN.KS,
				BIK = CZN.BIK,
				INN = CZN.INN,
				KPP = CZN.KPP,
				OGRN = CZN.OGRN,
				DocumentOfOrganisation = CZN.DocumentOfOrganisation,
				PhoneNumber = CZN.PhoneNumber,
				//PersonId = CZN.PersonId,
				//Person = CZN.Person,
				//Addresses = CZN.Addresses.ToList(),
			};
			return View(editCZNVM);
		}

		[HttpPost]
		public async Task<IActionResult> EditCZN(int id, EditCZNViewModel editCZNViewModel)
		{
			if (id == null)
			{
				return NotFound();
			}

			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Ошибка сохранения");
				return View(editCZNViewModel);
			}

			var CZN = new CZN
			{
				Id = id,
				FullName = editCZNViewModel.FullName,
				ShortName = editCZNViewModel.ShortName,
				Email = editCZNViewModel.Email,
				RS = editCZNViewModel.RS,
				BankForRS = editCZNViewModel.BankForRS,
				KS = editCZNViewModel.KS,
				BIK = editCZNViewModel.BIK,
				INN = editCZNViewModel.INN,
				KPP = editCZNViewModel.KPP,
				OGRN = editCZNViewModel.OGRN,
				DocumentOfOrganisation = editCZNViewModel.DocumentOfOrganisation,
				PhoneNumber = editCZNViewModel.PhoneNumber,
				//PersonId = editCZNViewModel.PersonId,
				//Person = editCZNViewModel.Person,
				//Addresses = editCZNViewModel.Addresses.ToList(),
			};

			_CZNRepository.Update(CZN);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			if (id == null) return NotFound();

			var CZN = await _CZNRepository.GetByIdAsync(id);
			if (CZN == null) return NotFound();

			return View(CZN);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteCZN(int id)
		{
			if (id == null) return NotFound();

			var CZN = await _CZNRepository.GetByIdForRemovingAsync(id);

			if (CZN == null) return NotFound();

			_CZNRepository.Delete(CZN);
			//_organisationRepository.Save();

			return RedirectToAction("Index");
		}

        [HttpGet]
        public async Task<IActionResult> File(int id)
        {
            if (id == null) return NotFound();

            var CZN = await _context.CZNs.Include(x => x.Files).FirstOrDefaultAsync(x => x.Id == id);

            if (CZN == null) return NotFound();

            var vm = new AddCZNFilesViewModel
            {
                CZNId = CZN.Id,
                CZN = CZN,
                Files = CZN.Files
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> File(IFormFile file, int id)
        {
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(file.OpenReadStream()))
            {
                bytes = br.ReadBytes((int)file.Length);
            }

            using (SqlConnection connection = new SqlConnection())
            {
                //connection.ConnectionString =
                //  "Data Source=localhost\\SQLEXPRESS;" +
                //  "Initial Catalog=VolgStoiDb;" +
                //  "Integrated Security=SSPI;" +
                //  "Trusted_Connection = true;" +
                //              "TrustServerCertificate = true;";

                connection.ConnectionString =
                  "Data Source=KISELEVAE;" +
                  "Initial Catalog=VolgStoiDb;" +
                  "Integrated Security=SSPI;" +
                  "Trusted_Connection = true;" +
                  "TrustServerCertificate = true;";

                string query = "INSERT INTO Files (FileName, ContentType, Data, CZNId) VALUES (@FileName, @ContentType, @Data, @CZNId)";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@FileName", Path.GetFileName(file.FileName));
                    cmd.Parameters.AddWithValue("@ContentType", file.ContentType);
                    cmd.Parameters.AddWithValue("@Data", bytes);
                    cmd.Parameters.AddWithValue("@CZNId", id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public FileResult DownloadFile(int? fileId)
        {
            byte[] bytes;
            string fileName, contentType;

            using (SqlConnection connection = new SqlConnection())
            {
                //connection.ConnectionString =
                //  "Data Source=localhost\\SQLEXPRESS;" +
                //  "Initial Catalog=VolgStoiDb;" +
                //  "Integrated Security=SSPI;" +
                //  "Trusted_Connection = true;" +
                //  "TrustServerCertificate = true;";

                connection.ConnectionString =
                      "Data Source=KISELEVAE;" +
                      "Initial Catalog=VolgStoiDb;" +
                      "Integrated Security=SSPI;" +
                      "Trusted_Connection = true;" +
                      "TrustServerCertificate = true;";

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT FileName, Data, ContentType FROM Files WHERE Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", fileId);
                    cmd.Connection = connection;
                    connection.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["Data"];
                        contentType = sdr["ContentType"].ToString();
                        fileName = sdr["FileName"].ToString();
                    }
                    connection.Close();
                }
            }

            return File(bytes, contentType, fileName);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFile(int? id)
        {
            if (id != null)
            {
                var file = await _context.Files.FirstOrDefaultAsync(x => x.Id == id);
                if (file != null)
                {
                    _context.Files.Remove(file);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}

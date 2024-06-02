using Kiseleva.GraduationProject.Data;
using Kiseleva.GraduationProject.Entities;
using Kiseleva.GraduationProject.Interfaces;
using Kiseleva.GraduationProject.Models;
using Kiseleva.GraduationProject.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using X.PagedList;

namespace Kiseleva.GraduationProject.Controllers
{
    public class OrganisationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IOrganisationRepository _organisationRepository;

        public OrganisationController(ApplicationDbContext context, IOrganisationRepository organisationRepository)
        {
            _context = context;
            _organisationRepository = organisationRepository;
        }

        [HttpGet]
        [Route("Organisations")]
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

            var organisations = from p in _context.Organisations // возможно, прописать новый метод в интерфейсе
                         select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                organisations = organisations.Where(p => p.FullName.Contains(searchString) || p.ShortName.Contains(searchString) || p.Email.Contains(searchString));
                return View(organisations);
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
        public async Task<IActionResult> InformationAboutOrganisation(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organisation = await _organisationRepository.GetByIdAsync(id);

            if (organisation == null)
            {
                return NotFound();
            }

            var viewModel = new InformationAboutOrganisationViewModel
            {
                Id = id,
                FullName = organisation.FullName,
                ShortName = organisation.ShortName,
                Email = organisation.Email,
                RS = organisation.RS,
                BankForRS = organisation.BankForRS,
                KS = organisation.KS,
                BIK = organisation.BIK,
                INN = organisation.INN,
                KPP = organisation.KPP,
                OGRN = organisation.OGRN,
                DocumentOfOrganisation = organisation.DocumentOfOrganisation,
                PhoneNumber = organisation.PhoneNumber,
                Addresses = organisation.Addresses.Where(x => x.Organisation.Id == id).ToList(),
                Person = organisation.Person,
                Files = await _context.Files.Where(x => x.OrganisationId == id).ToListAsync(),
            };
            return View(viewModel);

        }

        [HttpGet]
        public async Task<IActionResult> CreateOrganisation()
        {
            var createOrganisationViewModel = new CreateOrganisationViewModel();
            return View(createOrganisationViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrganisation(CreateOrganisationViewModel createOrganisationViewModel)
        {
            if (ModelState.IsValid)
            {
                var organisation = new Organisation()
                {
                    FullName = createOrganisationViewModel.FullName,
                    ShortName = createOrganisationViewModel.ShortName,
                    Email = createOrganisationViewModel.Email,
                    RS = createOrganisationViewModel.RS,
                    BankForRS = createOrganisationViewModel.BankForRS,
                    KS = createOrganisationViewModel.KS,
                    BIK = createOrganisationViewModel.BIK,
                    INN = createOrganisationViewModel.INN,
                    KPP = createOrganisationViewModel.KPP,
                    OGRN = createOrganisationViewModel.OGRN,
                    DocumentOfOrganisation = createOrganisationViewModel.DocumentOfOrganisation,
                    PhoneNumber = createOrganisationViewModel.PhoneNumber,

                    Person = new Person
                    {
                        LastName = createOrganisationViewModel.Person.LastName,
                        FirstName = createOrganisationViewModel.Person.FirstName,
                        MiddleName = createOrganisationViewModel.Person.MiddleName,
                        KindOfPerson = createOrganisationViewModel.Person.KindOfPerson,
                    },

                    Addresses = new List<Address>
                    { 
                        new Address
                        {
                            Region = createOrganisationViewModel.Addresses[0].Region,
                            District = createOrganisationViewModel.Addresses[0].District,
                            Settlement = createOrganisationViewModel.Addresses[0].Settlement,
                            Street = createOrganisationViewModel.Addresses[0].Street,
                            Building = createOrganisationViewModel.Addresses[0].Building,
                            Apartment = createOrganisationViewModel.Addresses[0].Apartment,
                            Index = createOrganisationViewModel.Addresses[0].Index,
                            KindOfAddress = createOrganisationViewModel.Addresses[0].KindOfAddress,
                        },

                        new Address
                        {
                            Region = createOrganisationViewModel.Addresses[1].Region,
                            District = createOrganisationViewModel.Addresses[1].District,
                            Settlement = createOrganisationViewModel.Addresses[1].Settlement,
                            Street = createOrganisationViewModel.Addresses[1].Street,
                            Building = createOrganisationViewModel.Addresses[1].Building,
                            Apartment = createOrganisationViewModel.Addresses[1].Apartment,
                            Index = createOrganisationViewModel.Addresses[1].Index,
                            KindOfAddress = createOrganisationViewModel.Addresses[1].KindOfAddress,
                        }
                    },
                };

                _organisationRepository.Add(organisation);
                _organisationRepository.Save();

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Ошибка добавления новой организации");
            }

            return View(createOrganisationViewModel);
        }

		[HttpGet]
		public async Task<IActionResult> EditOrganisation(int id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var organisation = await _organisationRepository.GetByIdAsync(id);

			if (organisation == null) return NotFound();

			var editOrganisationVM = new EditOrganisationViewModel
			{
				FullName = organisation.FullName,
				ShortName = organisation.ShortName,
				Email = organisation.Email,
                RS = organisation.RS,
                BankForRS = organisation.BankForRS,
                KS = organisation.KS,
				BIK = organisation.BIK,
				INN = organisation.INN,
                KPP = organisation.KPP,
				OGRN = organisation.OGRN,
                DocumentOfOrganisation = organisation.DocumentOfOrganisation,
				PhoneNumber = organisation.PhoneNumber,
                PersonId = organisation.PersonId,
				Person = organisation.Person,
				Addresses = organisation.Addresses.ToList(),
			};
			return View(editOrganisationVM);
		}

		[HttpPost]
		public async Task<IActionResult> EditOrganisation(int id, EditOrganisationViewModel editOrganisationVM)
		{
			if (id == null)
			{
				return NotFound();
			}

			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Ошибка сохранения");
				return View(editOrganisationVM);
			}

			var organisation = new Organisation
			{
				Id = id,
				FullName = editOrganisationVM.FullName,
				ShortName = editOrganisationVM.ShortName,
				Email = editOrganisationVM.Email,
                RS = editOrganisationVM.RS,
                BankForRS = editOrganisationVM.BankForRS,
                KS = editOrganisationVM.KS,
                BIK = editOrganisationVM.BIK,
				INN = editOrganisationVM.INN,
                KPP = editOrganisationVM.KPP,
				OGRN = editOrganisationVM.OGRN,
                DocumentOfOrganisation = editOrganisationVM.DocumentOfOrganisation,
				PhoneNumber = editOrganisationVM.PhoneNumber,
                PersonId = editOrganisationVM.PersonId,
				Person = editOrganisationVM.Person,
				Addresses = editOrganisationVM.Addresses.ToList(),
			};

			_organisationRepository.Update(organisation);

			return RedirectToAction("Index");
		}

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null) return NotFound();

            var organisation = await _organisationRepository.GetByIdAsync(id);
            if (organisation == null) return NotFound();

            return View(organisation);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteOrganisation(int id)
        {
            if (id == null) return NotFound();

            var organisation = await _organisationRepository.GetByIdForRemovingAsync(id);

            if (organisation == null) return NotFound();

            _organisationRepository.Delete(organisation);
            //_organisationRepository.Save();

            return RedirectToAction("Index");
        }

		[HttpGet]
		public async Task<IActionResult> File(int id)
		{
			if (id == null) return NotFound();

			var organisation = await _context.Organisations.Include(x => x.Files).FirstOrDefaultAsync(x => x.Id == id);

			if (organisation == null) return NotFound();

			var vm = new AddOrganisationFilesViewModel
			{
				OrganisationId = organisation.Id,
				Organisation = organisation,
				Files = organisation.Files
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

				string query = "INSERT INTO Files (FileName, ContentType, Data, OrganisationId) VALUES (@FileName, @ContentType, @Data, @OrganisationId)";
				using (SqlCommand cmd = new SqlCommand(query))
				{
					cmd.Connection = connection;
					cmd.Parameters.AddWithValue("@FileName", Path.GetFileName(file.FileName));
					cmd.Parameters.AddWithValue("@ContentType", file.ContentType);
					cmd.Parameters.AddWithValue("@Data", bytes);
					cmd.Parameters.AddWithValue("@OrganisationId", id);
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
